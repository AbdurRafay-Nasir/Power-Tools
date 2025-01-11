using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FoldoutGroupAttribute : PropertyAttribute, IGroupAttribute, IPaddingMargin
    {
        private readonly string name;
        private readonly bool open;

        public float PaddingLeft { get; set; }
        public float PaddingRight { get; set; }
        public float PaddingTop { get; set; }
        public float PaddingBottom { get; set; }
        public float MarginLeft { get; set; }
        public float MarginRight { get; set; }
        public float MarginTop { get; set; }
        public float MarginBottom { get; set; }

        public FoldoutGroupAttribute(string name, bool open = false)
        {
            this.name = name;
            this.open = open;
        }

        public VisualElement CreateGroupGUI()
        {
            Foldout foldout = new Foldout();
            foldout.AddToClassList("unity-list-view__foldout-header");

            foldout.text = name;
            foldout.value = open;
            foldout.viewDataKey = $"{name}_foldout";

            foldout.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            foldout.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return foldout;
        }
    }
}