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

        // viewDataKey doesn't work for Tab
        public VisualElement CreateGroupGUI() => new Tab(tabName);
    }
}