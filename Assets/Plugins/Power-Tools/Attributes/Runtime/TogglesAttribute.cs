using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TogglesAttribute : UnityEngine.PropertyAttribute
    {
        #region Padding

        public float PaddingLeft { get; set; } = 6f;
        public float PaddingRight { get; set; } = 6f;
        public float PaddingTop { get; set; }
        public float PaddingBottom { get; set; }
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

        public Alignment Alignment { get; set; } = Alignment.Center;
        public float FontSize { get; set; } = 15f;
        public string[] ToggleNames { get; }

        /// <summary>
        /// Creates Toggle Buttons on top of component.
        /// </summary>
        /// <param name="toggles">Comma separated words: "Walk, Sprint, Swim"</param>
        public TogglesAttribute(string toggles)
        {
            ToggleNames = GetToggleNames(toggles);
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