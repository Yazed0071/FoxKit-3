using Assets.Fox.EdGraphx;
using Fox.GameService;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace FoxKit.Editor.GsRoute
{
    [CustomEditor(typeof(GsRouteData))]
    public class GsRouteDataEditor : GraphxSpatialGraphDataEditor
    {
        private GsRouteData Route => (GsRouteData)target;

        protected override void BuildExtraSections(VisualElement container)
        {
            Type edgeEventType = Route.GetEdgeEventType();
            Type nodeEventType = Route.GetNodeEventType();
            if (edgeEventType == null && nodeEventType == null)
                return;

            VisualElement edgeTemplate = new VisualElement();
            VisualElement nodeTemplate = new VisualElement();

            AddEventDropdown(container, "DefaultEdgeEvent", edgeEventType, "Default Edge Event", () =>
            {
                Route.SyncEventTemplates();
                RebuildTemplateSection(edgeTemplate, Route.GetEdgeEventTemplate());
            });
            container.Add(edgeTemplate);

            AddEventDropdown(container, "DefaultNodeEvent", nodeEventType, "Default Node Event", () =>
            {
                Route.SyncEventTemplates();
                RebuildTemplateSection(nodeTemplate, Route.GetNodeEventTemplate());
            });
            container.Add(nodeTemplate);

            container.schedule.Execute(() =>
            {
                if (target == null)
                    return;

                Route.SyncEventTemplates();
                RebuildTemplateSection(edgeTemplate, Route.GetEdgeEventTemplate());
                RebuildTemplateSection(nodeTemplate, Route.GetNodeEventTemplate());
            });
        }

        private void AddEventDropdown(VisualElement container, string propertyName, Type eventBaseType, string label, Action onChanged)
        {
            if (eventBaseType == null)
                return;

            var prop = serializedObject.FindProperty(propertyName);
            if (prop == null)
                return;

            const string none = "(None)";
            var choices = new List<string> { none };

            var names = new List<string>();
            foreach (Type type in TypeCache.GetTypesDerivedFrom(eventBaseType))
            {
                if (type.IsAbstract)
                    continue;

                names.Add(FriendlyEventName(type));
            }
            names.Sort();
            choices.AddRange(names);

            int index = choices.IndexOf(prop.stringValue);
            if (index < 0)
                index = 0;

            var popup = new PopupField<string>(label, choices, index);
            popup.RegisterValueChangedCallback(evt =>
            {
                var liveProp = serializedObject.FindProperty(propertyName);
                if (liveProp == null)
                    return;

                if (evt.newValue == none)
                    liveProp.stringValue = "";
                else
                    liveProp.stringValue = evt.newValue;

                serializedObject.ApplyModifiedProperties();
                onChanged?.Invoke();
            });
            container.Add(popup);
        }

        private void RebuildTemplateSection(VisualElement section, UnityEngine.Object template)
        {
            section.Clear();
            if (template == null)
                return;

            section.Add(new InspectorElement(template));
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
