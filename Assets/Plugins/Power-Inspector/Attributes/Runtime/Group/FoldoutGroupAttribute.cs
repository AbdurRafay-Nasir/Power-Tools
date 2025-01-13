using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FoldoutGroupAttribute : UnityEngine.PropertyAttribute, IGroupAttribute
    {
        #region Padding

        public float PaddingLeft { get; set; }
        public float PaddingRight { get; set; } = 2f;
        public float PaddingTop { get; set; } = 2f;
        public float PaddingBottom { get; set; } = 2f;
        public float PaddingHorizontal
        {
            set
            {
                PaddingLeft = value;
                PaddingRight = value;
            }
        }
        public float PaddingVertical
        {
            set
            {
                PaddingTop = value;
                PaddingBottom = value;
            }
        }
        public float Padding
        {
            set
            {
                PaddingLeft = value;
                PaddingRight = value;
                PaddingTop = value;
                PaddingBottom = value;
            }
        }

        #endregion

        #region Margin

        public float MarginLeft { get; set; }
        public float MarginRight { get; set; }
        public float MarginTop { get; set; }
        public float MarginBottom { get; set; }
        public float MarginHorizontal
        {
            set
            {
                MarginLeft = value;
                MarginRight = value;
            }
        }
        public float MarginVertical
        {
            set
            {
                MarginTop = value;
                MarginBottom = value;
            }
        }
        public float Margin
        {
            set
            {
                MarginLeft = value;
                MarginRight = value;
                MarginTop = value;
                MarginBottom = value;
            }
        }

        #endregion

        /// <summary>
        /// Text displayed after foldout arrow
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initial state of Foldout. Defaults to false
        /// </summary>
        private readonly bool open;

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