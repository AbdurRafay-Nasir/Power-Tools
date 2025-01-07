using System;
using UnityEngine.UIElements;
using PowerEditor.Attributes.Editor;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FoldoutGroupAttribute : PowerAttribute, IGroupAttribute
    {
        private readonly string name;
        private readonly Foldout foldout = new Foldout();

        #region Constructors

        public FoldoutGroupAttribute(string name)
        {
            this.name = name;
        }

        public FoldoutGroupAttribute(string name, float padding)
        {
            this.name = name;

            foldout.SetPadding(padding);
        }

        public FoldoutGroupAttribute(string name, float padding, float margin)
        {
            this.name = name;

            foldout.SetPadding(padding);
            foldout.SetMargin(margin);
        }

        public FoldoutGroupAttribute(string name,
                             float paddingHorizontal, float paddingVertical,
                             float marginHorizontal, float marginVertical)
        {
            this.name = name;

            foldout.SetPadding(paddingHorizontal, paddingVertical);
            foldout.SetMargin(marginHorizontal, marginVertical);
        }

        public FoldoutGroupAttribute(string name,
                             float paddingLeft, float paddingRight,
                             float paddingTop, float paddingBottom,
                             float marginLeft, float marginRight,
                             float marginTop, float marginBottom)
        {
            this.name = name;

            foldout.SetPadding(paddingLeft, paddingRight, paddingTop, paddingBottom);
            foldout.SetPadding(marginLeft, marginRight, marginTop, marginBottom);
        }

        #endregion

        public VisualElement CreateGroupGUI()
        {
            foldout.AddToClassList("unity-list-view__foldout-header");

            foldout.text = name;
            foldout.value = false;
            foldout.viewDataKey = $"{name}_foldout";

            return foldout;
        }
    }
}