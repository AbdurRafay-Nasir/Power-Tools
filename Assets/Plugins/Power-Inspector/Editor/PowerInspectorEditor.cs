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
