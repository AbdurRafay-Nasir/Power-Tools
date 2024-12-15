using System;
using UnityEngine.UIElements;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class FoldoutGroupAttribute : InspectorAttribute, IGroupAttribute
{
    public VisualElement CreateGroupGUI()
    {
        Foldout foldout = new Foldout();
        foldout.text = "F1";

        foldout.viewDataKey = "AAA";

        return foldout;
    }
}
