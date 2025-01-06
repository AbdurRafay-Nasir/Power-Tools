using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using System.Text.RegularExpressions;
using Codice.Client.BaseCommands.BranchExplorer;

namespace PowerEditor.Attributes.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class PowerInspectorEditor : UnityEditor.Editor
    {
        private List<SerializedProperty> serializedProperties = new();
        private Dictionary<SerializedProperty, SceneAttributeData> sceneAttributesDict = new();

        private Type targetType;

        private void OnEnable()
        {
            targetType = target.GetType();

            serializedProperties = serializedObject.GetAllSerializedProperties();
            
            // If the class is not marked with UsePowerSceneAttribute,
            // then don't process it
            if (targetType.GetCustomAttribute<UsePowerSceneAttribute>() == null)
                return;

            foreach (var property in serializedProperties)
            {
                List<Attribute> allAttributes = property.GetAttributes();
                List<ISceneAttribute> sceneAttributes = new();

                foreach (var attr in allAttributes)
                {
                    if (attr is ISceneAttribute sceneAttr)
                    {
                        sceneAttributes.Add(sceneAttr);
                    }
                }

                if (sceneAttributes.Count > 0)
                {
                    SceneAttributeData data = new SceneAttributeData();
                    data.fieldInfo = property.GetField();
                    data.sceneAttributes = sceneAttributes;

                    sceneAttributesDict.Add(property, data);
                }
            }

            // PrintDictionary();
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
                toggleButtonGroup = CreateTogglesGUI(togglesAttribute.toggleNames);
                currentParent.Add(toggleButtonGroup);
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
                        VisualElement group = groupAttribute.CreateGroupGUI(currentParent);

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

                // Finally, add the property field to the current parent
                currentParent.Add(new PropertyField(property));
            }

            MethodInfo[] methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (methods != null)
            {
                tree.Add(CreateMethodButtons(methods));
            }
            
            parentStack.Clear();

            return tree;
        }

        private void OnSceneGUI()
        {
            if (sceneAttributesDict.Count == 0)
                return;

            foreach (var entry in sceneAttributesDict)
            {
                SerializedProperty property = entry.Key;

                List<ISceneAttribute> sceneAttributes = sceneAttributesDict[property].sceneAttributes;
                foreach (var sceneAttr in sceneAttributes)
                {
                    sceneAttr.Draw(target, property, sceneAttributesDict[property].fieldInfo);
                }
            }
        }

        /// <summary>
        /// Constructs Toggle Buttons at top of Component
        /// </summary>
        /// <returns>Group of Toggle Buttons</returns>
        private ToggleButtonGroup CreateTogglesGUI(string[] toggleNames)
        {
            ToggleButtonGroup toggleButtonGroup = new ToggleButtonGroup();
            toggleButtonGroup.isMultipleSelection = true;
            toggleButtonGroup.allowEmptySelection = true;
            toggleButtonGroup.viewDataKey = target.GetInstanceID().ToString();

            // if number of buttons exceed available horizontal space,
            // move them to next line
            VisualElement toggleButtonsContainer = toggleButtonGroup.Q<VisualElement>("unity-toggle-button-group__container");
            toggleButtonsContainer.style.flexWrap = Wrap.Wrap;
            toggleButtonsContainer.style.alignSelf = Align.Center;

            for (int i = 0; i < toggleNames.Length; i++)
            {
                Button button = new Button();
                button.name = i + toggleNames[i];
                button.text = toggleNames[i];
                button.style.fontSize = 15f;
                button.style.paddingBottom = 5f;
                button.style.paddingTop = 5f;
                button.style.paddingRight = 10f;
                button.style.paddingLeft = 10f;
                button.style.marginRight = 5f;

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

        private void PrintDictionary()
        {
            foreach (var entry in sceneAttributesDict)
            {
                List<ISceneAttribute> attributes = sceneAttributesDict[entry.Key].sceneAttributes;

                foreach (var attr in attributes)
                {
                    Debug.Log(entry.Key.name + ": has " + attr.GetType().Name);
                }
            }
        }
    }

    internal struct SceneAttributeData
    {
        public List<ISceneAttribute> sceneAttributes;
        public FieldInfo fieldInfo;
    }

}