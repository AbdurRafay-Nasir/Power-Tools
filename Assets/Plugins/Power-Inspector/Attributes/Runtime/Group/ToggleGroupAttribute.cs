using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ToggleGroupAttribute : UnityEngine.PropertyAttribute
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

        public string toggleName;

        public ToggleGroupAttribute(string toggleName)
        {
            this.toggleName = toggleName;
        }
    }
}