using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MarginAttribute : UnityEngine.PropertyAttribute
    {
        #region Margin

        public float Left { get; set; }
        public float Right { get; set; }
        public float Top { get; set; }
        public float Bottom { get; set; }
        public float Horizontal
        {
            get => 0f;
            set
            {
                Left = value;
                Right = value;
            }
        }
        public float Vertical
        {
            get => 0f;
            set
            {
                Top = value;
                Bottom = value;
            }
        }
        public float All
        {
            get => 0f;
            set
            {
                Left = value;
                Right = value;
                Top = value;
                Bottom = value;
            }
        }

        #endregion
    }
}