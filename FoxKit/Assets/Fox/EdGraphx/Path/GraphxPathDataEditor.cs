using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxPathData), editorForChildClasses: true)]
    public class GraphxPathDataEditor : GraphxSpatialGraphDataEditor
    {
        private GraphxPathData Path => (GraphxPathData)Target;

        private bool HasFrameBounds() => Target.HasBounds();

        public Bounds OnGetFrameBounds() => Target.GetWorldBounds();
    }
}