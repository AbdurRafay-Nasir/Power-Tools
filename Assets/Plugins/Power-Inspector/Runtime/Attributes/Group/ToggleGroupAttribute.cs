using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ToggleGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public string toggleName;

        public ToggleGroupAttribute(string toggleName)
        {
            this.toggleName = toggleName;
        }

        public VisualElement CreateGroupGUI(in VisualElement parent)
        {
            VisualElement root = new VisualElement();

            Button button = parent.Q<Button>(toggleName);
            if (button == null)
                return root;

            button.RegisterCallback<ClickEvent>((evt) =>
            {
                Color bgColor = button.resolvedStyle.backgroundColor;
                string hex = ColorUtility.ToHtmlStringRGB(bgColor);

                root.style.display = (hex == "4F657F" || hex == "B0D2FC")
                                     ? DisplayStyle.Flex
                                     : DisplayStyle.None;
            });

            button.RegisterCallbackOnce<GeometryChangedEvent>((evt) =>
            {
                Color bgColor = button.resolvedStyle.backgroundColor;
                string hex = ColorUtility.ToHtmlStringRGB(bgColor);

                root.style.display = (hex == "46607C") ? DisplayStyle.Flex : DisplayStyle.None;
            });

            return root;
        }
    }
}