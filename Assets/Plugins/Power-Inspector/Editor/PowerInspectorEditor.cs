using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using PowerEditor.Attributes;

[CustomEditor(typeof(MonoBehaviour), true)]
public class PowerInspectorEditor : Editor
{
    private List<SerializedProperty> serializedProperties = new();
    private Dictionary<SerializedProperty, List<Attribute>> propertyAttributes = null;

    private bool hasUsePowerInspectorAttribute;
    private bool hasUsePowerSceneAttribute;

    private Type targetType;

    private void OnEnable()
    {
        serializedProperties = GetAllSerializedProperties();
        targetType = target.GetType();

        hasUsePowerInspectorAttribute = targetType.GetCustomAttribute<UsePowerInspectorAttribute>() != null;
        hasUsePowerSceneAttribute = targetType.GetCustomAttribute<UsePowerSceneAttribute>() != null;

        if (hasUsePowerInspectorAttribute || hasUsePowerSceneAttribute)
        {
            propertyAttributes = new();

            foreach (var property in serializedProperties)
            {
                propertyAttributes.Add(property, GetAttributes(property));
            }
        }

        foreach (var entry in propertyAttributes)
        {
            List<Attribute> attributes = propertyAttributes[entry.Key];

            foreach (var attr in attributes)
            {
                Debug.Log(entry.Key.name + ": " + attr.GetType().Name);
            }
        }

    }

    public override VisualElement CreateInspectorGUI()
    {
        if (!hasUsePowerInspectorAttribute)
            return base.CreateInspectorGUI();

        VisualElement tree = new VisualElement();
        Stack<VisualElement> parentStack = new Stack<VisualElement>();

        VisualElement currentParent = tree;

        TitleAttribute titleAttribute = targetType.GetCustomAttribute<TitleAttribute>();
        if (titleAttribute != null)
        {
            Box box = new Box();
            box.style.backgroundColor = titleAttribute.backgroundColor;

            Label label = new Label(titleAttribute.titleText);

            label.style.alignSelf = titleAttribute.alignment;
            label.style.fontSize = titleAttribute.fontSize;
            label.style.color = titleAttribute.textColor;

            box.Add(label);
            tree.Add(box);
        }

        CommentAttribute commentAttribute = targetType.GetCustomAttribute<CommentAttribute>();
        if (commentAttribute != null)
        {
            Box box = new Box();

            ColorUtility.TryParseHtmlString("#416141", out Color color);
            box.style.backgroundColor = color;
            box.style.borderBottomLeftRadius = 5f;
            box.style.borderBottomRightRadius = 5f;
            box.style.borderTopLeftRadius = 5f;
            box.style.borderTopRightRadius = 5f;

            box.style.paddingLeft = 5f;
            box.style.paddingRight = 5f;
            box.style.paddingBottom = 5f;
            box.style.paddingTop = 5f;

            if (titleAttribute != null)
                box.style.marginTop = 5f;

            Label label = new Label(commentAttribute.comment);
            label.style.color = Color.white;
            label.style.whiteSpace = WhiteSpace.Normal;
            label.style.overflow = Overflow.Visible;

            box.Add(label);
            tree.Add(box);
        }

        foreach (var property in serializedProperties)
        {
            List<Attribute> allAttributes = GetAttributes(property);

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
                    for (int i = 0; i < endGroupAttribute.openGroupsToClose; i++)
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
            List<Attribute> attributes = propertyAttributes[property];

            Transform transform = (target as MonoBehaviour).transform;

            foreach (var attribute in attributes)
            {
                if (attribute is DrawLineAttribute)
                {
                    Handles.DrawLine(transform.position, property.vector3Value);
                }

                if (attribute is PositionHandleAttribute)
                {
                    FieldInfo field = targetType.GetField(property.name);

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

    private List<SerializedProperty> GetAllSerializedProperties()
    {
        List<SerializedProperty> serializedProperties = new();

        SerializedProperty iterator = serializedObject.GetIterator();
        iterator.NextVisible(true);

        bool isNextPropertyVisible = iterator.NextVisible(false);

        while (isNextPropertyVisible)
        {
            serializedProperties.Add(iterator.Copy());

            isNextPropertyVisible = iterator.NextVisible(false);
        }

        return serializedProperties;
    }

    private SerializedProperty GetPropertyWithAttribute<T>() where T : Attribute
    {
        Type targetType = target.GetType();
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        foreach (SerializedProperty property in serializedProperties)
        {
            FieldInfo field = targetType.GetField(property.name, bindingFlags);

            if (field.GetCustomAttribute<T>() != null)
                return property;
        }

        return null;
    }

    private T GetAttribute<T>(SerializedProperty property) where T : Attribute
    {
        Type targetType = target.GetType();
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        FieldInfo field = targetType.GetField(property.name, bindingFlags);

        return field.GetCustomAttribute<T>();
    }

    private List<Attribute> GetAttributes(SerializedProperty property)
    {
        Type targetType = target.GetType();
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        FieldInfo field = targetType.GetField(property.name, bindingFlags);

        return new List<Attribute>(field.GetCustomAttributes(false) as Attribute[]);
    }
}
