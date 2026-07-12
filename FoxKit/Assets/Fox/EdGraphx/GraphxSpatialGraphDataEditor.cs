using Fox.Graphx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphData), true)]
    public class GraphxSpatialGraphDataEditor : UnityEditor.Editor
    {
        protected GraphxSpatialGraphData Target => (GraphxSpatialGraphData)base.target;

        protected bool HasFrameBounds() => Target.HasBounds();

        protected Bounds OnGetFrameBounds() => Target.GetWorldBounds();

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new VisualElement();

            Button addNodeButton = new Button(OnAddNodeButtonClicked) { text = "Add Node" };
            container.Add(addNodeButton);

            BuildExtraSections(container);

            GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
            field.Build(this.serializedObject);
            container.Add(field);

            return container;
        }

        protected virtual void BuildExtraSections(VisualElement container) { }

        private void OnAddNodeButtonClicked()
        {
            int undoGroup = Undo.GetCurrentGroup();
            bool wasEmpty = Target.nodes.Count == 0;
            GraphxSpatialGraphDataNode node = Target.AddNode();

            if (wasEmpty && node != null)
            {
                if (HandleUtility.PlaceObject(Event.current.mousePosition, out Vector3 placedPosition, out _))
                {
                    Undo.RecordObject(node, "Place First Node");
                    node.transform.position = placedPosition;
                }
            }

            Undo.CollapseUndoOperations(undoGroup);
            Selection.activeGameObject = node.gameObject;
        }
    }
}
