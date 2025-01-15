using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TogglesAttribute : UnityEngine.PropertyAttribute
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
        
        public string[] ToggleNames { get; }
        public Alignment Alignment { get; set; }
        public float FontSize { get; set; } = 15f;

        public TogglesAttribute(string toggles)
        {
            ToggleNames = GetToggleNames(toggles);

            Alignment = Alignment.Center;
            FontSize = 15f;

            PaddingLeft = 6f;
            PaddingRight = 6f;
        }

        /// <summary>
        /// Converts "Walk, Sprint, Swim" to ["Walk", "Sprint", "Swim"]
        /// </summary>
        /// <param name="toggles">The string to convert</param>
        private string[] GetToggleNames(string toggles)
        {
            string[] names = toggles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < names.Length; i++)
                names[i] = names[i].Trim();

            return names;
        }
    }
}