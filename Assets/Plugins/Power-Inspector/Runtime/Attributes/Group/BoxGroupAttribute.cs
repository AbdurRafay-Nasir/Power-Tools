using System;
using UnityEngine;
using UnityEngine.UIElements;
using PowerEditor.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class BoxGroupAttribute : InspectorAttribute, IGroupAttribute
{
    public VisualElement CreateGroupGUI()
    {
        GroupBox groupBox = new GroupBox();

        groupBox.style.borderLeftWidth = 5f;
        groupBox.style.borderRightWidth = 5f;
        groupBox.style.borderTopWidth = 5f;
        groupBox.style.borderBottomWidth = 5f;

        groupBox.style.borderRightColor = Color.green;
        groupBox.style.borderLeftColor = Color.green;
        groupBox.style.borderTopColor = Color.green;
        groupBox.style.borderBottomColor = Color.green;

        return groupBox;
    }
}
