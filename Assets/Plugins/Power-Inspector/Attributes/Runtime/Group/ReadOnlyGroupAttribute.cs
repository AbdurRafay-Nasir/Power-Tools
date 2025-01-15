using System;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyGroupAttribute : UnityEngine.PropertyAttribute, IGroupAttribute
    {
        #region Padding

        public float PaddingLeft { get; set; }
        public float PaddingRight { get; set; } = 2f;
        public float PaddingTop { get; set; } = 2f;
        public float PaddingBottom { get; set; } = 2f;
        public float PaddingHorizontal
        {
            get => 0f; set
            {
                PaddingLeft = value;
                PaddingRight = value;
            }
        }
        public float PaddingVertical
        {
            get => 0f; set
            {
                PaddingTop = value;
                PaddingBottom = value;
            }
        }
        public float Padding
        {
            get => 0f; set
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
            get => 0f; set
            {
                MarginLeft = value;
                MarginRight = value;
            }
        }
        public float MarginVertical
        {
            get => 0f; set
            {
                MarginTop = value;
                MarginBottom = value;
            }
        }
        public float Margin
        {
            get => 0f; set
            {
                MarginLeft = value;
                MarginRight = value;
                MarginTop = value;
                MarginBottom = value;
            }
        }

        #endregion

        public VisualElement CreateGroupGUI()
        {
            VisualElement root = new VisualElement();

            root.SetEnabled(false);

            root.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            root.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return root;
        }
    }
}