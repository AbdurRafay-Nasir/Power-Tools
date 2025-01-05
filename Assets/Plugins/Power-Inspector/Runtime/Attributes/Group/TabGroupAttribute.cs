using System;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TabGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public string tabName;

        public TabGroupAttribute(string tabName)
        {
            this.tabName = tabName;
        }

        public VisualElement CreateGroupGUI(in VisualElement parent)
        {
            return new Tab(tabName);
        }
    }
}