using System;
using UnityEngine.UIElements;
using PowerEditor.Attributes.Editor;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TabViewAttribute : PowerAttribute, IGroupAttribute
    {
        // viewDataKey doesn't work for TabView
        public VisualElement CreateGroupGUI()
        {
            TabView tabView = new TabView();

            tabView.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            tabView.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return tabView;
        }
    }
}