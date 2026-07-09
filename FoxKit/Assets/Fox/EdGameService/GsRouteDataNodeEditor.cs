using Fox.EdGraphx;
using Fox.GameService;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdGameService
{
    [CustomEditor(typeof(GsRouteDataNode))]
    public class GsRouteDataNodeEditor : GraphxSpatialGraphDataNodeEditor
    {
        private GsRouteDataNode Node => (GsRouteDataNode)target;

        protected override void BuildExtraSections(VisualElement container)
        {
            GsRouteData eventGraph = Node.transform.GetComponentInParent<GsRouteData>();
            if (eventGraph == null || eventGraph.GetNodeEventType() == null)
                return;

            Button addNodeEventButton = new Button();
            addNodeEventButton.text = "Add Node Event";
            addNodeEventButton.clicked += OnAddNodeEventButtonClicked;
            container.Add(addNodeEventButton);

            VisualElement eventTypeSection = new VisualElement();
            container.Add(eventTypeSection);
            int builtCount = -1;
            int filledCount = Node.GetDirectionCount();

            container.schedule.Execute(() =>
            {
                if (target == null || eventGraph == null)
                    return;

                int count = Node.GetDirectionCount();

                if (count > filledCount && eventGraph.ResolveNodeEvents(Node, filledCount))
                    serializedObject.Update();
                filledCount = count;

                if (count != builtCount)
                {
                    BuildEventTypeDropdowns(eventTypeSection, eventGraph);
                    builtCount = count;
                }
            }).Every(200);
        }

        private void OnAddNodeEventButtonClicked()
        {
            GsRouteData graph = Node.transform.GetComponentInParent<GsRouteData>();
            if (graph == null)
                return;

            int undoGroup = Undo.GetCurrentGroup();
            graph.AddNodeEvent(Node);
            Undo.CollapseUndoOperations(undoGroup);
        }

        private void BuildEventTypeDropdowns(VisualElement section, GsRouteData eventGraph)
        {
            section.Clear();

            int count = Node.GetDirectionCount();
            for (int i = 0; i < count; i++)
            {
                string currentName = Node.events[i].action;

                int selected = GameServiceModule.RouteNodeEvents.IndexOf(currentName);

                PopupField<string> dropdown = new PopupField<string>($"Event {i} Type", GameServiceModule.RouteNodeEvents, selected);
                dropdown.RegisterValueChangedCallback(evt => eventGraph.SetNodeEventType(Node, i, evt.newValue));
                section.Add(dropdown);
            }
        }
    }
}
