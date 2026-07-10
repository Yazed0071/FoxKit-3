using System;
using UnityEditor;
using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteDataNode : Fox.Graphx.GraphxSpatialGraphDataNode
    {
        public override int GetDirectionCount() => events.Count;

        public override float GetDirection(int index)
        {
            if (index >= 0 && index < events.Count && events[index] != null)
                return events[index].dir.eulerAngles.y;

            return 0f;
        }

        public override void SetDirection(int index, float value)
        {
            if (index < 0 || index >= events.Count || events[index] == null)
                return;
            
            Undo.RecordObject(events[index], "Set Node Event Direction");
            events[index].dir = Quaternion.AngleAxis(value, Vector3.up);
        }
    }
}
