using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataNode), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataNodeEditor : EntityEditor
    {
        private GraphxSpatialGraphDataNode Target => (GraphxSpatialGraphDataNode)target;
        private GraphxSpatialGraphData Graph => target.transform.parent.GetComponent<GraphxSpatialGraphData>();

        private bool HasFrameBounds() => Graph != null;

        public Bounds OnGetFrameBounds() => new Bounds(Graph.transform.TransformPoint(Target.position), new Vector3(1, 1, 1));

        private void OnEnable()
        {
            Tools.hidden = true;
        }

        private void OnDisable()
        {
            Tools.hidden = false;
        }

        protected virtual void OnSceneGUI()
        {
            if (Graph == null)
                return;

            Handles.matrix = Graph.transform.localToWorldMatrix;

            EditorGUI.BeginChangeCheck();
            Vector3 newTargetPosition = Handles.PositionHandle(Target.position, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(Target, "Move GraphxSpatialGraphDataNode");
                Target.position = newTargetPosition;
            }

            if (Target.GetDirectionCount() > 0)
                DrawDirectionHandles();
        }

        private void DrawDirectionHandles()
        {
            Vector3 nodePos = Target.position;
            float size = HandleUtility.GetHandleSize(nodePos);
            int count = Target.GetDirectionCount();

            for (int i = 0; i < count; i++)
            {
                float dir = Target.GetDirection(i);
                Quaternion rot = Quaternion.Euler(0f, dir, 0f);
                Vector3 forward = rot * Vector3.forward;
                float radius = size * (1.2f + i * 0.5f);
                Vector3 tip = nodePos + forward * radius;

                Handles.color = Color.cyan;
                Handles.DrawLine(nodePos, tip);
                Handles.ConeHandleCap(0, tip, Quaternion.LookRotation(forward), size * 0.15f, EventType.Repaint);

                EditorGUI.BeginChangeCheck();
                Quaternion newRot = Handles.Disc(rot, nodePos, Vector3.up, radius, false, 0f);
                if (EditorGUI.EndChangeCheck())
                    Target.SetDirection(i, newRot.eulerAngles.y);
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new VisualElement();

            Button addNodeButton = new Button();
            addNodeButton.text = "Add Node";
            addNodeButton.clicked += OnAddNodeButtonClicked;
            container.Add(addNodeButton);

            Button deleteNodeButton = new Button();
            deleteNodeButton.text = "Delete Node";
            deleteNodeButton.clicked += OnDeleteNodeButtonClicked;
            container.Add(deleteNodeButton);

            Button nextNodeButton = new Button();
            nextNodeButton.text = "Next Node";
            nextNodeButton.clicked += OnNextNodeButtonClicked;
            container.Add(nextNodeButton);

            Button previousNodeButton = new Button();
            previousNodeButton.text = "Previous Node";
            previousNodeButton.clicked += OnPreviousNodeButtonClicked;
            container.Add(previousNodeButton);

            Button graphButton = new Button();
            graphButton.text = "Select Graph";
            graphButton.clicked += OnGraphButtonClicked;
            container.Add(graphButton);

            BuildExtraSections(container);

            GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
            field.Build(this.serializedObject);
            container.Add(field);

            return container;
        }

        protected virtual void BuildExtraSections(VisualElement container) { }

        private void OnAddNodeButtonClicked()
        {
            var graph = Target.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Target);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            // Create node at current position
            var newNode = graph.AddNodeAfter(Target);
            newNode.position = Target.position;
            Selection.activeGameObject = newNode.gameObject;
        }

        private void OnDeleteNodeButtonClicked()
        {
            var graph = Target.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Target);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            GameObject selectAfter = graph.gameObject;
            if (graph.nodes.Count > 1)
            {
                int neighbourIndex;
                if (index > 0)
                    neighbourIndex = index - 1;
                else
                    neighbourIndex = 1;
                selectAfter = graph.GetGraphNode(neighbourIndex).gameObject;
            }

            graph.RemoveNode(Target);
            Selection.activeGameObject = selectAfter;
        }

        private void OnNextNodeButtonClicked()
        {
            var graph = Target.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Target);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            var nextIndex = index + 1;
            if (nextIndex >= graph.nodes.Count)
            {
                nextIndex = 0;
            }

            var nextNode = graph.GetGraphNode(nextIndex);
            if (nextNode == null)
            {
                Debug.LogError($"Next graph node is null. Did you delete a node without removing it from parent's {nameof(GraphxSpatialGraphData.nodes)} property?");
            }

            Selection.activeGameObject = nextNode.gameObject;
        }

        private void OnPreviousNodeButtonClicked()
        {
            var graph = Target.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
                return;
            }

            var index = graph.IndexOf(Target);
            if (index == -1)
            {
                Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
                return;
            }

            var nextIndex = index - 1;
            if (nextIndex < 0)
            {
                nextIndex = graph.nodes.Count - 1;
            }

            var nextNode = graph.GetGraphNode(nextIndex);
            if (nextNode == null)
            {
                Debug.LogError($"Previous graph node is null. Did you delete a node without removing it from parent's {nameof(GraphxSpatialGraphData.nodes)} property?");
            }

            Selection.activeGameObject = nextNode.gameObject;
        }

        private void OnGraphButtonClicked()
        {
            var graph = Target.transform.GetComponentInParent<GraphxSpatialGraphData>();
            if (graph == null)
            {
                Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
                return;
            }

            Selection.activeGameObject = graph.gameObject;
        }
    }
}
