using Fox.EdGraphx;
using Fox.GameService;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

namespace FoxKit.Editor.GsRoute
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

            Type typeBase = eventGraph.GetNodeEventType();
            if (typeBase == null)
                return;

            const string none = "(None)";
            List<string> choices = new List<string> { none };

            List<string> names = new List<string>();
            foreach (Type type in TypeCache.GetTypesDerivedFrom(typeBase))
            {
                if (type.IsAbstract)
                    continue;

                names.Add(FriendlyEventName(type));
            }
            names.Sort();
            choices.AddRange(names);

            int count = Node.GetDirectionCount();
            for (int i = 0; i < count; i++)
            {
                int index = i;
                Type type = Node.GetNodeEventTypeAt(index);
                string currentName = type != null ? FriendlyEventName(type) : none;

                int selected = choices.IndexOf(currentName);
                if (selected < 0)
                    selected = 0;

                PopupField<string> dropdown = new PopupField<string>($"Event {index} Type", choices, selected);
                dropdown.RegisterValueChangedCallback(evt =>
                    eventGraph.SetNodeEventType(Node, index, evt.newValue == none ? "" : evt.newValue));
                section.Add(dropdown);
            }
        }

        private static string FriendlyEventName(Type type)
        {
            string name = type.Name;
            if (name.StartsWith("TppRoute"))
                name = name.Substring("TppRoute".Length);

            if (name.EndsWith("EdgeEvent"))
                name = name.Substring(0, name.Length - "EdgeEvent".Length);
            else if (name.EndsWith("NodeEvent"))
                name = name.Substring(0, name.Length - "NodeEvent".Length);

            return name;
        }
    }
}
