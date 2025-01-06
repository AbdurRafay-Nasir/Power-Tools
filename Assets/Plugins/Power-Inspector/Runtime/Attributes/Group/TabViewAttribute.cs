using System;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TabViewAttribute : PowerAttribute, IGroupAttribute
    {
        public VisualElement CreateGroupGUI() => new TabView();
    }
}