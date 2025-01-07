using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TogglesAttribute : PowerAttribute
    {
        public string[] ToggleNames { get; }
        public Alignment Alignment { get; set; }
        public float FontSize { get; set; } = 15f;
        public new float PaddingLeft { get; set; } = 6f;
        public new float PaddingRight { get; set; } = 6f;

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