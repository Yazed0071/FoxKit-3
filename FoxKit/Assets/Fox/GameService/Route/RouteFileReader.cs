using Fox.Core.Utils;
using Fox.Graphx;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Fox.GameService
{
    public class RouteFileReader
    {
        private readonly TaskLogger Logger = new TaskLogger("ImportRouteFile");

        public unsafe UnityEngine.SceneManagement.Scene? Read(ReadOnlySpan<byte> data)
        {
            fixed (byte* dataPtr = data)
            {
                RouteFile.BaseHeader* baseHeader = (RouteFile.BaseHeader*)dataPtr;

                if (baseHeader->Signature != RouteFile.Signature)
                {
                    Logger.AddError($"Read failed. Not a ROUT.");
                    return null;
                }

                RouteFile.FormatVersion version = (RouteFile.FormatVersion)baseHeader->Version;
                if (version != RouteFile.FormatVersion.V2 && version != RouteFile.FormatVersion.V3)
                {
                    Logger.AddError($"Version {version} isn't supported");
                    return null;
                }

                UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

                ushort routeCount;
                Vector3 origin;
                StrCode32* routeIds;
                RouteFile.RouteDef* routeDefs;
                if (version == RouteFile.FormatVersion.V2)
                {
                    RouteFile.HeaderV2* header = (RouteFile.HeaderV2*)dataPtr;

                    routeCount = header->RouteCount;
                    origin = Math.FoxToUnityVector3(header->Origin);
                    routeIds = (StrCode32*)(dataPtr + header->RouteIdsOffset);
                    routeDefs = (RouteFile.RouteDef*)(dataPtr + header->RouteDefinitionsOffset);
                }
                else
                {
                    RouteFile.HeaderV3* header = (RouteFile.HeaderV3*)dataPtr;

                    routeCount = header->RouteCount;
                    origin = Vector3.zero;
                    routeIds = (StrCode32*)(dataPtr + header->RouteIdsOffset);
                    routeDefs = (RouteFile.RouteDef*)(dataPtr + header->RouteDefinitionsOffset);
                }
                
                List<GsRouteData> routeDatas = new List<GsRouteData>(routeCount);
                for (int i = 0; i < routeCount; i++)
                {
                    string routeId = GameServiceModule.RouteIdMap.Resolve(routeIds[i], out string routeIdString) ? routeIdString : routeIds[i].ToString();

                    RouteFile.RouteDef* routeDef = routeDefs + i;

                    GsRouteData routeData = new GameObject().AddComponent<GsRouteData>();
                    routeData.name = routeId;
                    routeDatas.Add(routeData);

                    for (int j = 0; j < routeDef->NodeCount; j++)
                    {
                        GsRouteDataNode node = new GameObject($"GsRouteDataNode{j:D4}").AddComponent<GsRouteDataNode>();
                        node.SetOwner(routeData);
                        routeData.nodes.Add(node);
                        
                        GsRouteDataEdge edge = new GameObject($"GsRouteDataEdge{j:D4}").AddComponent<GsRouteDataEdge>();
                        edge.SetOwner(routeData);
                        routeData.edges.Add(edge);

                        // Position
                        if (version == RouteFile.FormatVersion.V2)
                        {
                            ulong packedVertex = ((ulong*)((byte*)routeDef + routeDef->VerticesOffset))[j];

                            uint packedX = (uint)(packedVertex & 0x003FFFFF);
                            if ((packedX & (1 << 21)) != 0)
                                packedX |= 0xFFC00000;
                            float x = (float)(int)packedX / 1024;

                            uint packedY = (uint)((packedVertex >> 22) & 0x000FFFFF);
                            if ((packedY & (1 << 19)) != 0)
                                packedY |= 0xFFF00000;
                            float y = (float)(int)packedY / 1024;

                            uint packedZ = (uint)((packedVertex >> 42) & 0x003FFFFF);
                            if ((packedZ & (1 << 21)) != 0)
                                packedZ |= 0xFFC00000;
                            float z = (float)(int)packedZ / 1024;

                            node.position = Math.FoxToUnityVector3(new Vector3(x, y, z)) + origin;
                        }
                        else
                        {
                            Vector3 vertex = ((Vector3*)((byte*)routeDef + routeDef->VerticesOffset))[j];
                            node.position = Math.FoxToUnityVector3(vertex);
                        }

                        // Events
                        RouteFile.EventSpan* eventSpan = (RouteFile.EventSpan*)((byte*)routeDef + routeDef->EventSpanOffset) + j;

                        for (int k = 0; k < eventSpan->Count; k++)
                        {
                            RouteFile.EventDef* evt = (RouteFile.EventDef*)((byte*)routeDef + routeDef->EventsOffset) + (eventSpan->StartIndex + k);
                            byte* aimPointData = (byte*)evt + (version == RouteFile.FormatVersion.V2 ? 0x0C : 0x10);

                            Debug.Assert(evt->BodySectionType == RouteBodySectionType.Head);

                            
                            string eventId = GameServiceModule.EventIdMap.Resolve(evt->Id, out string eventIdString) ? eventIdString : evt->Id.ToString();
                            GameObject routeEventObject = new GameObject();

                            GsRouteDataEventAimPoint aimPoint = null;
                            switch (evt->AimTargetType)
                            {
                                case RouteAimTargetType.NoTarget:
                                    break;
                                case RouteAimTargetType.StaticPoint:
                                {
                                    GsRouteDataEventAimStaticPoint aimStaticPoint = new GameObject().AddComponent<GsRouteDataEventAimStaticPoint>();
                                    
                                    Vector3 position = *(Vector3*)aimPointData;
                                    aimStaticPoint.position = Math.FoxToUnityVector3(position);
                                    
                                    aimPoint = aimStaticPoint;
                                    break;
                                }
                                case RouteAimTargetType.Character:
                                {
                                    GsRouteDataEventAimCharacter aimCharacter = new GameObject().AddComponent<GsRouteDataEventAimCharacter>();
                                    
                                    StrCode32 characterId = *(StrCode32*)aimPointData;
                                    aimCharacter.characterId = characterId.ToString();
                                    
                                    aimPoint = aimCharacter;
                                    break;
                                }
                                case RouteAimTargetType.RouteAsSightMovePath:
                                {
                                    GsRouteDataEventAimRouteAsSightMovePath aimRouteAsSightMovePath = new GameObject().AddComponent<GsRouteDataEventAimRouteAsSightMovePath>();
                                    
                                    StrCode32* aimPointRouteIds = (StrCode32*)aimPointData;
                                    aimRouteAsSightMovePath.routeId_AddElement(0, aimPointRouteIds[0].ToString());
                                    aimRouteAsSightMovePath.routeId_AddElement(1, aimPointRouteIds[1].ToString());
                                    aimRouteAsSightMovePath.routeId_AddElement(2, aimPointRouteIds[2].ToString());
                                    aimRouteAsSightMovePath.routeId_AddElement(3, aimPointRouteIds[3].ToString());

                                    aimPoint = aimRouteAsSightMovePath;
                                    break;
                                }
                                case RouteAimTargetType.RouteAsObject:
                                {
                                    GsRouteDataEventAimRouteAsObject aimRouteAsObject = new GameObject().AddComponent<GsRouteDataEventAimRouteAsObject>();
                                    
                                    StrCode32* aimPointRouteIds = (StrCode32*)aimPointData;
                                    aimRouteAsObject.routeId_AddElement(0, aimPointRouteIds[0].ToString());
                                    aimRouteAsObject.routeId_AddElement(1, aimPointRouteIds[1].ToString());
                                    aimRouteAsObject.routeId_AddElement(2, aimPointRouteIds[2].ToString());
                                    aimRouteAsObject.routeId_AddElement(3, aimPointRouteIds[3].ToString());
                                    
                                    aimPoint = aimRouteAsObject;
                                    break;
                                }
                            }

                            if (evt->Type == RouteEventType.Edge)
                            {
                                GsRouteDataEdgeEvent edgeEvent = (GsRouteDataEdgeEvent)(GameServiceModule.RouteEdgeEventMap.TryGetValue(evt->Id, out Type eventType)
                                    ? routeEventObject.AddComponent(eventType)
                                    : routeEventObject.AddComponent<GsRouteDataEdgeEvent>());
                                edge.@event = edgeEvent;

                                edgeEvent.move = eventId;
                                
                                edgeEvent.transform.parent = edge.transform;
                                edgeEvent.name = $"GsRouteDataEdgeEvent{k:D4}";

                                if (aimPoint is not null)
                                {
                                    aimPoint.SetOwner(routeData);
                                    edgeEvent.aimPoint = aimPoint;
                                    aimPoint.transform.parent = edgeEvent.transform;
                                    aimPoint.name = $"{aimPoint.GetClassEntityInfo().Name}";
                                }
                            }
                            else
                            {
                                GsRouteDataNodeEvent nodeEvent = (GsRouteDataNodeEvent)(GameServiceModule.RouteNodeEventMap.TryGetValue(evt->Id, out Type eventType)
                                    ? routeEventObject.AddComponent(eventType)
                                    : routeEventObject.AddComponent<GsRouteDataNodeEvent>());
                                node.events.Add(nodeEvent);

                                nodeEvent.action = eventId;
                                nodeEvent.isLoop = evt->IsLoop;
                                nodeEvent.time = evt->GetTime();
                                nodeEvent.dir = evt->GetDir();

                                nodeEvent.transform.parent = node.transform;
                                nodeEvent.name = $"GsRouteDataNodeEvent{k:D4}";

                                if (aimPoint is not null)
                                {
                                    nodeEvent.aimPoint = aimPoint;
                                    aimPoint.SetOwner(routeData);
                                    aimPoint.name = $"{aimPoint.GetClassEntityInfo().Name}";
                                }
                            }
                        }
                    }

                    for (int j = 0; j < routeDef->NodeCount; j++)
                    {
                        GraphxSpatialGraphDataNode node = routeData.nodes[j];
                        GraphxSpatialGraphDataEdge prevEdge = routeData.edges[j];
                        GraphxSpatialGraphDataEdge nextEdge = routeData.edges[(j + 1 + routeDef->NodeCount) % routeDef->NodeCount];

                        node.outlinks.Add(prevEdge);
                        prevEdge.nextNode = node;
                        node.outlinks.Add(nextEdge);
                        nextEdge.prevNode = node;
                    }
                }

                return scene;
            }
        }
    }
}