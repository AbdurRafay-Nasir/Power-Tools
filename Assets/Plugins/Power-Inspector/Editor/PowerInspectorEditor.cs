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
        private Dictionary<SerializedProperty, List<ISceneAttribute>> sceneAttributesDict = new();

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
                    sceneAttributesDict.Add(property, sceneAttributes);
                }
            }

            // PrintDictionary();
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement tree = new VisualElement();
            Stack<VisualElement> parentStack = new Stack<VisualElement>();

            VisualElement currentParent = tree;

            foreach (var property in serializedProperties)
            {
                List<Attribute> allAttributes = property.GetAttributes();

                foreach (var attribute in allAttributes)
                {
                    if (attribute is IGroupAttribute groupAttribute)
                    {
                        VisualElement group = groupAttribute.CreateGroupGUI();

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

                List<ISceneAttribute> sceneAttributes = sceneAttributesDict[property];
                foreach (var sceneAttr in sceneAttributes)
                {
                    sceneAttr.Draw(target, property);
                }
            }
        }

        private void SetVector3Value(FieldInfo field)
        {
            Vector3 oldVal = (Vector3)field.GetValue(target);
            Vector3 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

            if (newVal != oldVal)
            {
                Undo.RecordObject(target, "undo Vector3 value");
                field.SetValue(target, newVal);
            }
        }

        private void SetVector2Value(FieldInfo field)
        {
            Vector2 oldVal = (Vector2)field.GetValue(target);
            Vector2 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

            if (newVal != oldVal)
            {
                Undo.RecordObject(target, "undo Vector2 value");
                field.SetValue(target, newVal);
            }
        }

        private void PrintDictionary()
        {
            foreach (var entry in sceneAttributesDict)
            {
                List<ISceneAttribute> attributes = sceneAttributesDict[entry.Key];

                foreach (var attr in attributes)
                {
                    Debug.Log(entry.Key.name + ": has " + attr.GetType().Name);
                }
            }
        }
    }

}