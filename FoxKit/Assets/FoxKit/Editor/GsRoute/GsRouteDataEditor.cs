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
            VisualElement edgeTemplate = new VisualElement();
            VisualElement nodeTemplate = new VisualElement();

            AddEventDropdown(container, "DefaultEdgeEvent", GameServiceModule.RouteEdgeEvents, "Default Edge Event", () =>
            {
                Route.SyncEventTemplates();
                RebuildTemplateSection(edgeTemplate, Route.GetEdgeEventTemplate());
            });
            container.Add(edgeTemplate);

            AddEventDropdown(container, "DefaultNodeEvent", GameServiceModule.RouteNodeEvents, "Default Node Event", () =>
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

        private void AddEventDropdown(VisualElement container, string propertyName, List<(string Id, Type Type)> events, string label, Action onChanged)
        {
            var prop = serializedObject.FindProperty(propertyName);
            if (prop == null)
                return;

            const string none = "(None)";
            var choices = new List<string> { none };
            foreach ((string id, Type _) in events)
                choices.Add(id);

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
    }
}
