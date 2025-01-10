using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FoldoutGroupAttribute : PowerAttribute, IGroupAttribute
    {
        private readonly string name;
        private readonly bool open;

        private readonly string guidString;

        public FoldoutGroupAttribute(string name, bool open = false)
        {
            this.name = name;
            this.open = open;

            guidString = Guid.NewGuid().ToString();
        }

        public VisualElement CreateGroupGUI()
        {
            Foldout foldout = new Foldout();
            foldout.AddToClassList("unity-list-view__foldout-header");

            foldout.text = name;
            foldout.value = open;
            foldout.viewDataKey = guidString;

            foldout.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            foldout.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return foldout;
        }
    }
}