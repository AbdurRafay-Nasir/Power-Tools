using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using PowerEditor.Attributes;
using PowerEditor.Misc;

namespace PowerEditor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class PowerInspectorEditor : Editor
    {
        private List<SerializedProperty> serializedProperties = new();
        private Dictionary<SerializedProperty, List<SceneAttribute>> sceneAttributesDict = null;

        private bool hasUsePowerInspectorAttribute;
        private bool hasUsePowerSceneAttribute;

        private Type targetType;

        private void OnEnable()
        {
            targetType = target.GetType();

            hasUsePowerInspectorAttribute = targetType.GetCustomAttribute<UsePowerInspectorAttribute>() != null;
            hasUsePowerSceneAttribute = targetType.GetCustomAttribute<UsePowerSceneAttribute>() != null;
            
            serializedProperties = serializedObject.GetAllSerializedProperties(false);

            // If the class is not marked with UsePowerSceneAttribute,
            // then don't process it
            if (!hasUsePowerSceneAttribute)
                return;

            sceneAttributesDict = new();

            foreach (var property in serializedProperties)
            {
                List<Attribute> allAttributes = property.GetAttributes();
                List<SceneAttribute> sceneAttributes = new();

                foreach (var attr in allAttributes)
                {
                    if (attr is SceneAttribute sceneAttr)
                    {
                        sceneAttributes.Add(sceneAttr);
                    }
                }

                if (sceneAttributes.Count > 0)
                {
                    sceneAttributesDict.Add(property, sceneAttributes);
                }
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement tree = new VisualElement();

            PropertyField scriptField = new PropertyField(serializedProperties[0]);
            scriptField.SetEnabled(false);

            tree.Add(scriptField);
            
            if (!hasUsePowerInspectorAttribute)
            {
                for (int i = 1; i < serializedProperties.Count; i++)
                {
                    tree.Add(new PropertyField(serializedProperties[i]));
                }

                return tree;
            }
            
            Stack<VisualElement> parentStack = new Stack<VisualElement>();

            VisualElement currentParent = tree;

            for (int i = 1; i < serializedProperties.Count; i++)
            {
                SerializedProperty property = serializedProperties[i];
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

            parentStack.Clear();

            return tree;
        }

        private void OnSceneGUI()
        {
            if (!hasUsePowerSceneAttribute)
                return;

            foreach (var property in serializedProperties)
            {
                if (!sceneAttributesDict.ContainsKey(property))
                    continue;

                List<SceneAttribute> sceneAttributes = sceneAttributesDict[property];

                foreach (var attr in sceneAttributes)
                {

                    if (attr is DrawLineAttribute drawLineAttribute)
                    {
                        Transform transform = (target as MonoBehaviour).transform;

                        Color prevColor = Handles.color;
                        Handles.color = drawLineAttribute.lineColor;

                        Handles.DrawLine(transform.position, property.vector3Value, 
                                         drawLineAttribute.lineThickness);

                        Handles.color = prevColor;
                    }
                    else if (attr is PositionHandleAttribute)
                    {
                        FieldInfo field = property.GetField();

                        if (property.propertyType == SerializedPropertyType.Vector3)
                        {
                            SetVector3Value(field);
                        }
                        else if (property.propertyType == SerializedPropertyType.Vector2)
                        {
                            SetVector2Value(field);
                        }
                    }

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
                List<SceneAttribute> attributes = sceneAttributesDict[entry.Key];

                foreach (var attr in attributes)
                {
                    Debug.Log("Printed: " + entry.Key.name + ": " + attr.GetType().Name);
                }
            }
        }
    }

}