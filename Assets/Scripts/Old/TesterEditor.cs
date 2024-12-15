using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

// [CustomEditor(typeof(MonoBehaviour), true)]
public class TesterEditor : Editor
{
    //private List<SerializedProperty> serializedProperties = new();

    //private void OnEnable()
    //{
    //    serializedProperties = GetAllSerializedProperties();
    //}

    //public override VisualElement CreateInspectorGUI()
    //{
    //    if (target.GetType().GetCustomAttribute<ModifiableAttribute>() == null)
    //        return base.CreateInspectorGUI();

    //    VisualElement tree = new VisualElement();
    //    Stack<VisualElement> parentStack = new Stack<VisualElement>();
    //    parentStack.Push(tree); // Root parent

    //    foreach (var property in serializedProperties)
    //    {
    //        List<Attribute> allAttributes = GetAttributes(property);

    //        // Track the current parent
    //        VisualElement currentParent = parentStack.Peek();

    //        foreach (var attribute in allAttributes)
    //        {
    //            if (attribute is GroupAttribute groupAttribute)
    //            {
    //                // Create the group UI
    //                VisualElement group = groupAttribute.CreateGroupGUI();
    //                currentParent.Add(group); // Add the group to the current parent
    //                parentStack.Push(group);  // Push this group to the stack
    //                currentParent = group;    // Update current parent
    //            }
    //            else if (attribute is EndGroupAttribute)
    //            {
    //                // Pop the parent stack safely, handling multiple EndGroups
    //                parentStack.Pop();
    //                currentParent = parentStack.Peek();
    //            }
    //        }

    //        // Finally, add the property field to the current parent
    //        currentParent.Add(new PropertyField(property));
    //    }

    //    parentStack.Clear();

    //    // Return the root element
    //    return tree;
    //}


    ////public override VisualElement CreateInspectorGUI()
    ////{
    ////    if (target.GetType().GetCustomAttribute<ModifiableAttribute>() == null)
    ////        return base.CreateInspectorGUI();

    ////    //List<SerializedProperty> propertiesWithBoxGroupAttr = new();
    ////    //bool requireEndGroupAttr = false;

    ////    //foreach (SerializedProperty prop in serializedProperties)
    ////    //{
    ////    //    BoxGroupAttribute attr = GetAttribute<BoxGroupAttribute>(prop);

    ////    //    if (attr != null)
    ////    //    {
    ////    //        propertiesWithBoxGroupAttr.Add(prop);
    ////    //        requireEndGroupAttr = true;

    ////    //        continue;
    ////    //    }

    ////    //    if (requireEndGroupAttr)
    ////    //    {
    ////    //        propertiesWithBoxGroupAttr.Add(prop);
    ////    //        EndGroupAttribute endGroup = GetAttribute<EndGroupAttribute>(prop);

    ////    //        if (endGroup != null)
    ////    //            break;
    ////    //    }
    ////    //}

    ////    VisualElement tree = new VisualElement();

    ////    Stack<VisualElement> parentStack = new Stack<VisualElement>();
    ////    parentStack.Push(tree);

    ////    VisualElement currentParent = parentStack.Peek();

    ////    foreach (var property in serializedProperties)
    ////    {
    ////        List<Attribute> allAttributes = GetAttributes(property);

    ////        // if there are no attributes, simply show the property
    ////        if (allAttributes.Count == 0)
    ////        {
    ////            currentParent.Add(new PropertyField(property));
    ////            continue;
    ////        }

    ////        // if there is an attribute, make sure it is an Inspector Attribute
    ////        if (!HasInspectorAttribute(property, allAttributes))
    ////            continue;

    ////        currentParent = parentStack.Peek();

    ////        for (int i = 0; i < allAttributes.Count; i++)
    ////        {
    ////            if (allAttributes[i] is GroupAttribute)
    ////            {
    ////                VisualElement group = (allAttributes[i] as GroupAttribute).CreateGroupGUI();

    ////                currentParent.Add(group);
    ////                parentStack.Push(group);

    ////                currentParent = parentStack.Peek();
    ////            }

    ////            if (allAttributes[i] is EndGroupAttribute)
    ////            {

    ////            }

    ////            if (i + 1 == allAttributes.Count)
    ////            {
    ////                currentParent.Add(new PropertyField(property));
    ////                continue;
    ////            }

    ////        }

    ////        //if (group != null)
    ////        //{
    ////        //    group.Add(new PropertyField(property));
    ////        //}
    ////        //else
    ////        //{
    ////        //    tree.Add(new PropertyField(property));
    ////        //}

    ////    }

    ////    return tree;
    ////}

    //private bool HasInspectorAttribute(SerializedProperty property, List<Attribute> attributes)
    //{
    //    // Ensure that we are working ONLY with PowerAttributes, If
    //    PowerAttribute powerAttr = attributes.Find(attr =>
    //                                                  attr is PowerAttribute)
    //                                                  as PowerAttribute;
    //    if (powerAttr == null)
    //        return false;

    //    // Ensure that we have an Inspector Attribute
    //    InspectorAttribute inspectorAttr = attributes.Find(attr =>
    //                                                          attr is InspectorAttribute)
    //                                                          as InspectorAttribute;
    //    if (inspectorAttr == null)
    //        return false;

    //    return true;
    //}

    //private List<SerializedProperty> GetAllSerializedProperties()
    //{
    //    List<SerializedProperty> serializedProperties = new();

    //    SerializedProperty iterator = serializedObject.GetIterator();
    //    iterator.NextVisible(true);

    //    bool isNextPropertyVisible = iterator.NextVisible(false);

    //    while (isNextPropertyVisible)
    //    {
    //        serializedProperties.Add(iterator.Copy());

    //        isNextPropertyVisible = iterator.NextVisible(false);
    //    }

    //    return serializedProperties;
    //}

    //private SerializedProperty GetPropertyWithAttribute<T>() where T : Attribute
    //{
    //    Type targetType = target.GetType();
    //    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

    //    foreach (SerializedProperty property in serializedProperties)
    //    {
    //        FieldInfo field = targetType.GetField(property.name, bindingFlags);

    //        if (field.GetCustomAttribute<T>() != null)
    //            return property;
    //    }

    //    return null;
    //}

    //private T GetAttribute<T>(SerializedProperty property) where T : Attribute
    //{
    //    Type targetType = target.GetType();
    //    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

    //    FieldInfo field = targetType.GetField(property.name, bindingFlags);

    //    return field.GetCustomAttribute<T>();
    //}

    //private List<Attribute> GetAttributes(SerializedProperty property)
    //{
    //    Type targetType = target.GetType();
    //    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

    //    FieldInfo field = targetType.GetField(property.name, bindingFlags);

    //    return new List<Attribute>(field.GetCustomAttributes(false) as Attribute[]);
    //}
}

// This will be used after
//foreach (var attribute in allAttributes)
//{
//    if (attribute is SinglePropertyAttribute)
//    {
//        tree.Add((attribute as SinglePropertyAttribute).CreatePropertyGUI(property));

//    }
//}

//// Ensure that it is Multi Property Attribute
//MultiPropertyAttribute multiPropAttr = allAttributes.Find(attr =>
//                                                          attr.GetType() == typeof(MultiPropertyAttribute))
//                                                          as MultiPropertyAttribute;

//if (multiPropAttr != null)
//{
//    // code for multi property attribute
//    // tree.Add(multiPropAttr.CreateGroupGUI(property));
//}
