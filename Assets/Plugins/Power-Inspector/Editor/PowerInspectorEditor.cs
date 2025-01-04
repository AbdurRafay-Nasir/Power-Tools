using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

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
            if (togglesAttribute != null)
            {
                CreateToggles(currentParent, togglesAttribute.toggleNames);
            }

            foreach (var property in serializedProperties)
            {
                List<Attribute> allAttributes = property.GetAttributes();

                foreach (var attribute in allAttributes)
                {
                    if (attribute is IGroupAttribute groupAttribute)
                    {
                        VisualElement group = groupAttribute.CreateGroupGUI(currentParent);

                        currentParent.Add(group);

                        parentStack.Push(currentParent);
                        currentParent = group;
                    }
                    else if (attribute is EndGroupAttribute endGroupAttribute)
                    {
                        for (int j = 0; j < endGroupAttribute.openGroupsToClose; j++)
                            currentParent = parentStack.Pop();
                    }
                }

                // Finally, add the property field to the current parent
                currentParent.Add(new PropertyField(property));
            }

            MethodInfo[] methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
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

                tree.Add(button);
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

        private void CreateToggles(VisualElement parent, string[] toggleNames)
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

            foreach (string name in toggleNames)
            {
                Button button = new Button();
                button.name = name;
                button.text = name;
                button.style.fontSize = 15f;
                button.style.paddingBottom = 5f;
                button.style.paddingTop = 5f;
                button.style.paddingRight = 10f;
                button.style.paddingLeft = 10f;
                button.style.marginRight = 5f;

                toggleButtonGroup.Add(button);
            }

            parent.Add(toggleButtonGroup);
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