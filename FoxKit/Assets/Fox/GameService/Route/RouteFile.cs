using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.GameService
{
    internal static class RouteFile
    {
        public const uint Signature = 0x54554F52; // ROUT
        
        public enum FormatVersion : ushort
        {
            V2 = 0x0002,
            V3 = 0x0003,
            
            V2_BE = 0x0200,
            V3_BE = 0x0300,
        }
        
        // Hack to "preview" version before reading requisite header
        [StructLayout(LayoutKind.Sequential)]
        public struct BaseHeader
        {
            public uint Signature;
            public FormatVersion Version;
            public ushort RouteCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HeaderV2
        {
            // BaseHeader
            public uint Signature;
            public FormatVersion Version;
            public ushort RouteCount;

            public UnityEngine.Vector3 Origin;
            
            public uint RouteIdsOffset;
            public uint RouteDefinitionsOffset;
            public uint RouteNodesOffset;
            public uint RouteEventTablesOffset;
            public uint RouteEventsOffset;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0x10)]
        public struct HeaderV3
        {
            // BaseHeader
            public uint Signature;
            public FormatVersion Version;
            public ushort RouteCount;
            
            public uint RouteIdsOffset;
            public uint RouteDefinitionsOffset;
            public uint RouteNodesOffset;
            public uint RouteEventTablesOffset;
            public uint RouteEventsOffset;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct RouteDef
        {
            public uint VerticesOffset;
            public uint EventSpanOffset;
            public uint EventsOffset;
            public ushort NodeCount;
            public ushort EventCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EventSpan
        {
            public ushort Count;
            public ushort StartIndex;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct EventDef
        {
            public StrCode32 Id;
            public RouteEventType Type;
            public RouteAimTargetType AimTargetType;
            public RouteBodySectionType BodySectionType;
            public bool IsLoop;
            public ushort Time;
            public ushort Dir;

            public float GetTime() => Time / (60f * 1000f / 1001f);

            private const float DIR_TO_RAD = 2f * Mathf.PI / (UInt16.MaxValue + 1);

            public Quaternion GetDir() => Math.FoxToUnityQuaternion(Quaternion.AngleAxis(Dir * DIR_TO_RAD, Math.UnityToFoxVector3(Vector3.up)));
            //public float GetDirRotY() => Dir * ;
        }
    }
}
