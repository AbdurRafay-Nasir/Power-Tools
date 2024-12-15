using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomEditor(typeof(MonoBehaviour), true)]
public class PowerInspectorEditor : Editor
{
    private List<SerializedProperty> serializedProperties = new();

    private void OnEnable()
    {
        serializedProperties = GetAllSerializedProperties();
    }

    public override VisualElement CreateInspectorGUI()
    {
        Type targetType = target.GetType();

        if (targetType.GetCustomAttribute<UsePowerEditorAttribute>() == null)
            return base.CreateInspectorGUI();

        VisualElement tree = new VisualElement();
        Stack<VisualElement> parentStack = new Stack<VisualElement>();
        parentStack.Push(tree); // Root parent

        TitleAttribute titleAttribute = targetType.GetCustomAttribute<TitleAttribute>();
        if (titleAttribute != null)
        {
            Label title = new Label();

            title.text = "Title";
            title.style.alignSelf = Align.Center;
            title.style.fontSize = 30f;
            title.style.color = Color.red;

            tree.Add(title);
        }

        foreach (var property in serializedProperties)
        {
            List<Attribute> allAttributes = GetAttributes(property);

            // Track the current parent
            VisualElement currentParent = parentStack.Peek();

            foreach (var attribute in allAttributes)
            {
                if (attribute is IGroupAttribute groupAttribute)
                {
                    // Create the group UI
                    VisualElement group = groupAttribute.CreateGroupGUI();
                    currentParent.Add(group); // Add the group to the current parent
                    parentStack.Push(group);  // Push this group to the stack
                    currentParent = group;    // Update current parent
                }
                else if (attribute is EndGroupAttribute)
                {
                    // Pop the parent stack safely, handling multiple EndGroups
                    parentStack.Pop();
                    currentParent = parentStack.Peek();
                }
            }

            // Finally, add the property field to the current parent
            currentParent.Add(new PropertyField(property));
        }

        parentStack.Clear();

        return tree;
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
