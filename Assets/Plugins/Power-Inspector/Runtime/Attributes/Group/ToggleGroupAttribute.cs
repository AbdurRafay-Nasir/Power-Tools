using System;
using System.Text.RegularExpressions;
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
            ToggleButtonGroup toggleButtonGroup = parent.Q<ToggleButtonGroup>();
            VisualElement toggleButtonsContainer = toggleButtonGroup.Q<VisualElement>("unity-toggle-button-group__container");

            if (toggleButtonsContainer.childCount == 0)
                return new VisualElement();

            Button toggleButton = null;
            string buttonNameWithoutIndex = null;
            int index = -1;

            foreach (Button button in toggleButtonsContainer.Children())
            {
                buttonNameWithoutIndex = Regex.Replace(button.name, @"^\d+", "");

                if (toggleName.Equals(buttonNameWithoutIndex))
                {
                    // we found our button
                    index = int.Parse(Regex.Match(button.name, @"^\d+").Value);
                    toggleButton = button;
                    break;
                }
            }

            if (toggleButton == null)
                return new VisualElement();

            VisualElement root = new VisualElement();

            // Setup for Initial display, we can't do it in CreateGroupGUI as we need to 
            // know the state of toggle which is only valid once the Inspector is made
            toggleButton.RegisterCallbackOnce<GeometryChangedEvent>
            (
                (evt) => SetDisplay(root, toggleButtonGroup, index)
            );

            toggleButton.RegisterCallback<ClickEvent>
            (
                (evt) => SetDisplay(root, toggleButtonGroup, index)
            );

            return root;
        }

        private void SetDisplay(VisualElement parent, ToggleButtonGroup toggleButtonGroup, int toggleIndex)
        {
            ToggleButtonGroupState state = toggleButtonGroup.value;
            Span<int> activeOptions = state.GetActiveOptions(stackalloc int[state.length]);

            foreach (var activeOption in activeOptions)
            {
                if (toggleIndex == activeOption)
                {
                    // Toggle was active
                    parent.style.display = DisplayStyle.Flex;
                    return;
                }
            }

            parent.style.display = DisplayStyle.None;
        }
    }
}