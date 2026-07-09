using System;
using UnityEditor;

namespace Fox.GameService
{
    public partial class GsRouteDataNode : Fox.Graphx.GraphxSpatialGraphDataNode
    {
        public override int GetDirectionCount() => events.Count;

        public override float GetDirection(int index)
        {
            if (index >= 0 && index < events.Count && events[index] != null)
                throw new NotImplementedException("Need to refactor function to take quaternions.");
                //return events[index].direction;

            return 0f;
        }

        public override void SetDirection(int index, float value)
        {
            if (index < 0 || index >= events.Count || events[index] == null)
                return;

            throw new NotImplementedException("Need to refactor function to take quaternions.");
            
            Undo.RecordObject(events[index], "Set Node Event Direction");
            //events[index].dir = value;
        }
    }
}
