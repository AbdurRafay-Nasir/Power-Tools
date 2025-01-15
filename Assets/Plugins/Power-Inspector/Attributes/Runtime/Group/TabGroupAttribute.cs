using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TabGroupAttribute : UnityEngine.PropertyAttribute, IGroupAttribute
    {
        private readonly string tabName;

        public TabGroupAttribute(string tabName)
        {
            this.tabName = tabName;
        }

        // viewDataKey, Padding, margin doesn't work for Tab
        public VisualElement CreateGroupGUI() => new Tab(tabName);
    }
}