using Fox.Graphx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphData), true)]
    public class GraphxSpatialGraphDataEditor : UnityEditor.Editor
    {
        protected new GraphxSpatialGraphData Target => (GraphxSpatialGraphData)base.target;

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
                var sceneView = SceneView.lastActiveSceneView;
                if (sceneView != null)
                {
                    Undo.RecordObject(node, "Place First Node");
                    node.position = Target.transform.InverseTransformPoint(sceneView.pivot);
                }
            }

            Undo.CollapseUndoOperations(undoGroup);
            Selection.activeGameObject = node.gameObject;
        }
    }
}
