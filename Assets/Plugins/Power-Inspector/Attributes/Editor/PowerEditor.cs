#if UNITY_EDITOR

using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using System.Text.RegularExpressions;

namespace PowerTools.Attributes.Editor
{
    public class PowerEditor : UnityEditor.Editor
    {
        protected List<SerializedProperty> serializedProperties = new();
        private readonly List<PropertyField> propertyFields = new();
        private Type targetType;

        #region Unity Functions

        protected virtual void OnEnable()
        {
            targetType = target.GetType();
            serializedProperties = serializedObject.GetAllSerializedProperties();
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement tree = new VisualElement();
            Stack<VisualElement> parentStack = new Stack<VisualElement>();

            VisualElement currentParent = tree;

            TogglesAttribute togglesAttribute = targetType.GetCustomAttribute<TogglesAttribute>();
            ToggleButtonGroup toggleButtonGroup = null;
            if (togglesAttribute != null)
            {
                toggleButtonGroup = CreateTogglesGUI(togglesAttribute);
                currentParent.Add(toggleButtonGroup);
            }

            SearchableAttribute searchableAttribute = targetType.GetCustomAttribute<SearchableAttribute>();
            if (searchableAttribute != null)
            {
                ToolbarSearchField searchField = new ToolbarSearchField();
                searchField.style.alignSelf = Align.Center;
                currentParent.Add(searchField);

                searchField.RegisterValueChangedCallback((evt) =>
                {
                    foreach (PropertyField propField in propertyFields)
                    {
                        propField.style.display = propField.name.StartsWith(evt.newValue.ToLower())
                                                  ? DisplayStyle.Flex
                                                  : DisplayStyle.None;
                    }
                });
            }

            foreach (var property in serializedProperties)
            {
                List<Attribute> allAttributes = property.GetAttributes();

                foreach (var attribute in allAttributes)
                {
                    if (attribute is ToggleGroupAttribute toggleGroupAttribute)
                    {
                        if (toggleButtonGroup == null)
                        {
                            currentParent.Add(new HelpBox("<color=green>[ToggleGroup]</color> requires <color=green>[Toggles]</color> on class.", HelpBoxMessageType.Error));
                            continue;
                        }

                        Button toggleButton = GetToggleButton(toggleButtonGroup, toggleGroupAttribute.toggleName,
                                                              out int indexInToggleButtonGroup);

                        VisualElement toggleGroupRoot = new VisualElement();

                        toggleGroupRoot.SetPadding(toggleGroupAttribute.PaddingLeft, toggleGroupAttribute.PaddingRight,
                                                   toggleGroupAttribute.PaddingTop, toggleGroupAttribute.PaddingBottom);

                        toggleGroupRoot.SetMargin(toggleGroupAttribute.MarginLeft, toggleGroupAttribute.MarginRight,
                                                   toggleGroupAttribute.MarginTop, toggleGroupAttribute.MarginBottom);

                        toggleButton.RegisterCallbackOnce<GeometryChangedEvent>(
                            (evt) => SetToggleControlledGroupDisplay(toggleGroupRoot, toggleButtonGroup, indexInToggleButtonGroup));
                        toggleButton.RegisterCallback<ClickEvent>(
                            (evt) => SetToggleControlledGroupDisplay(toggleGroupRoot, toggleButtonGroup, indexInToggleButtonGroup));

                        currentParent.Add(toggleGroupRoot);
                        parentStack.Push(currentParent);
                        currentParent = toggleGroupRoot;
                    }
                    else if (attribute is IGroupAttribute groupAttribute)
                    {
                        VisualElement group = groupAttribute.CreateGroupGUI();

                        currentParent.Add(group);

                        parentStack.Push(currentParent);
                        currentParent = group;
                    }
                    else if (attribute is EndGroupAttribute endGroupAttribute)
                    {
                        int groupsToClose = endGroupAttribute.openGroupsToClose > parentStack.Count
                                            ? parentStack.Count
                                            : endGroupAttribute.openGroupsToClose;

                        for (int j = 0; j < groupsToClose; j++)
                            currentParent = parentStack.Pop();
                    }
                }

                PropertyField propertyField = new PropertyField(property);
                propertyField.name = property.name;
                propertyFields.Add(propertyField);

                // Finally, add the property field to the current parent
                currentParent.Add(propertyField);
            }

            MethodInfo[] methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (methods != null)
            {
                tree.Add(CreateMethodButtons(methods));
            }

            parentStack.Clear();

            return tree;
        }

        #endregion

        #region Custom Functions

        private VisualElement CreateMethodButtons(MethodInfo[] methods)
        {
            VisualElement buttons = new VisualElement();

            foreach (var method in methods)
            {
                ButtonAttribute buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();

                if (buttonAttribute == null)
                    continue;

                Button button = new Button();
                button.text = buttonAttribute.text;

                button.RegisterCallback<ClickEvent>((callback) =>
                {
                    method.Invoke(target, method.GetParameters());
                });

                buttons.Add(button);
            }

            return buttons;
        }

        /// <summary>
        /// Constructs Toggle Buttons at top of Component
        /// </summary>
        /// <returns>Group of Toggle Buttons</returns>
        private ToggleButtonGroup CreateTogglesGUI(TogglesAttribute attr)
        {
            ToggleButtonGroup toggleButtonGroup = new ToggleButtonGroup();
            toggleButtonGroup.isMultipleSelection = true;
            toggleButtonGroup.allowEmptySelection = true;
            toggleButtonGroup.viewDataKey = target.GetInstanceID().ToString();

            // if number of buttons exceed available horizontal space,
            // move them to next line
            VisualElement toggleButtonsContainer = toggleButtonGroup.Q<VisualElement>("unity-toggle-button-group__container");
            toggleButtonsContainer.style.flexWrap = Wrap.Wrap;
            toggleButtonsContainer.style.alignSelf = (Align)(int)attr.Alignment;

            for (int i = 0; i < attr.ToggleNames.Length; i++)
            {
                Button button = new Button();

                button.name = i + attr.ToggleNames[i];
                button.text = attr.ToggleNames[i];

                button.style.fontSize = attr.FontSize;
                button.SetPadding(attr.PaddingLeft, attr.PaddingRight, attr.PaddingTop, attr.PaddingBottom);
                button.SetMargin(attr.MarginLeft, attr.MarginRight, attr.MarginTop, attr.MarginBottom);

                toggleButtonGroup.Add(button);
            }

            return toggleButtonGroup;
        }

        /// <summary>
        /// Retrieves the Toggle Button whose name is <b>toggleName</b>
        /// </summary>
        /// <param name="toggleButtonGroup">The group to which this button belongs</param>
        /// <param name="toggleName">The Toggle name. Will be used to identify Toggle Button in ToggleButtonGroup</param>
        /// <param name="index">Index of Button in given ToggleButtonGroup</param>
        /// <returns>Toggle Button whose name is toggleName, null otherwise</returns>
        private Button GetToggleButton(ToggleButtonGroup toggleButtonGroup, string toggleName, out int index)
        {
            VisualElement toggleButtonsContainer = toggleButtonGroup.Q<VisualElement>("unity-toggle-button-group__container");
            string buttonNameWithoutIndex;
            index = -1;

            foreach (Button button in toggleButtonsContainer.Children())
            {
                buttonNameWithoutIndex = Regex.Replace(button.name, @"^\d+", "");

                if (buttonNameWithoutIndex.Equals(toggleName))
                {
                    index = int.Parse(Regex.Match(button.name, @"^\d+").Value);

                    return button;
                }
            }

            return null;
        }

        private void SetToggleControlledGroupDisplay(VisualElement parent, ToggleButtonGroup toggleButtonGroup, int toggleIndex)
        {
            ToggleButtonGroupState state = toggleButtonGroup.value;
            Span<int> activeOptions = state.GetActiveOptions(stackalloc int[state.length]);

            foreach (var activeOption in activeOptions)
            {
                if (toggleIndex == activeOption)
                {
                    parent.style.display = DisplayStyle.Flex;
                    return;
                }
            }

            parent.style.display = DisplayStyle.None;
        }

        #endregion
    }
}

#endif