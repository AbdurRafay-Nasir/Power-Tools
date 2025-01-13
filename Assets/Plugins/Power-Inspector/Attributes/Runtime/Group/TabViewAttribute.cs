using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TabViewAttribute : PowerAttribute, IGroupAttribute
    {
        public Alignment align;

        public TabViewAttribute(Alignment align = Alignment.Center)
        {
            this.align = align;
        }

        // viewDataKey doesn't work for TabView
        // Padding, Margin was not added as their can easily be created
        // by adding padding/margin on other attributes
        public VisualElement CreateGroupGUI()
        {
            TabView tabView = new TabView();

            VisualElement tabsContainer = tabView.Q<VisualElement>("unity-tab-view__header-container");
            tabsContainer.style.flexWrap = Wrap.Wrap;

            tabsContainer.style.alignSelf = (Align)(int)align;

            return tabView;
        }
    }
}