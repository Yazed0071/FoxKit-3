using Fox;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Fox.GameService
{
    public class GameServiceModule : Module
    {
        public static GameServiceModule Instance { get; private set; }

        internal static Dictionary<StrCode32, Type> RouteEdgeEventMap = new();
        internal static Dictionary<StrCode32, Type> RouteNodeEventMap = new();

        // Registered (name, type) pairs, in registration order, for editor UI.
        public static readonly List<(string Id, Type Type)> RouteEdgeEvents = new();
        public static readonly List<(string Id, Type Type)> RouteNodeEvents = new();

        internal static StringId32Map RouteIdMap = null;
        internal static StringId32Map EventIdMap = null;

        public GameServiceModule() : base("Fox.GameService")
        {
            Instance = this;
            
            AddDependencyModule("Fox.Kernel");
            AddDependencyModule("Fox.Core");
            AddDependencyModule("Fox.Graphx");
        }

        public static void RegisterRouteEdgeEventType(string id, Type type)
        {
            bool added = RouteEdgeEventMap.TryAdd(new StrCode32(id), type);
            Debug.Assert(added);
            if (added)
                RouteEdgeEvents.Add((id, type));
        }

        public static void RegisterRouteNodeEventType(string id, Type type)
        {
            bool added = RouteNodeEventMap.TryAdd(new StrCode32(id), type);
            Debug.Assert(added);
            if (added)
                RouteNodeEvents.Add((id, type));
        }

        public static void RegisterIdMaps(string routeIdDictionaryPath, string eventIdDictionaryPath)
        {
            RouteIdMap = new StringId32Map(routeIdDictionaryPath);
            EventIdMap = new StringId32Map(eventIdDictionaryPath);
        }

        public static void RegisterEventInfo(string eventInfoPath, string title)
        {
            List<(StrCode32, string)> eventIds = new List<(StrCode32, string)>();

            // Skip header row
            string[] eventInfo = Fox.Fs.FileSystem.ReadLines(eventInfoPath);
            for (uint i = 1; i < eventInfo.Length; i++)
            {
                string[] lineData = eventInfo[i].Split(',');

                string id = lineData[0];
                StrCode32 idHash = new StrCode32(lineData[1]);

                bool include = false;
                string[] testedInTitles = lineData[5].Split(',');
                foreach (string testedTitle in testedInTitles)
                {
                    if (testedTitle == title)
                    {
                        include = true;
                        break;
                    }
                }
                if (!include)
                    continue;

                eventIds.Add((idHash, id));
            }

            EventIdMap.AddBaseEntries(eventIds);
        }
    }
}
