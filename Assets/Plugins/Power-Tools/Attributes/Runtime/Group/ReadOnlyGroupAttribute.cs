using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyGroupAttribute : UnityEngine.PropertyAttribute, IGroupAttribute
    {
        public VisualElement CreateGroupGUI() 
        {
            VisualElement root = new VisualElement();

            root.SetEnabled(false);

            return root;
        }
    }
}