using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataNode
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            position = Fox.Math.FoxToUnityVector3(position);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(position), Fox.Math.UnityToFoxVector3(position));
        }

        public virtual int GetDirectionCount() => 0;
        public virtual float GetDirection(int index) => 0f;
        public virtual void SetDirection(int index, float value) { }

        public virtual System.Type GetNodeEventTypeAt(int index) => null;
    }
}