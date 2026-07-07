using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Geo
{
    public class GeoModule : Module
    {
        public static GeoModule Instance { get; private set; }

        internal static Dictionary<GeoPrimType, Func<GeomHeaderContext, TransformData>> GeoPrimDeserializationMap = new();

        public GeoModule() : base("Fox.Geo")
        {
            Instance = this;
        }

        public static void RegisterGeomHeaderDeserializationCallback(GeoPrimType type, Func<GeomHeaderContext, TransformData> deserializeFunc)
        {
            Debug.Assert(Enum.IsDefined(typeof(GeoPrimType), type));
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GeoPrimDeserializationMap.TryAdd(type, deserializeFunc));
        }
    }
}
