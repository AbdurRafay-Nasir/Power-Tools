using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TabGroupAttribute : PowerAttribute, IGroupAttribute
    {
        private readonly string tabName;

        public TabGroupAttribute(string tabName)
        {
            this.tabName = tabName;
        }

        // viewDataKey doesn't work for Tab
        public VisualElement CreateGroupGUI()
        {
            Tab tab = new Tab(tabName);

            tab.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            tab.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return tab;
        }
    }
}