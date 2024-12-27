using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TitleAttribute : PowerAttribute
    {
        public string titleText;
        public float fontSize;
        public Color textColor;
        public Align alignment;

        public Color backgroundColor;

        public TitleAttribute(string titleText, float fontSize = 20f, Align alignment = Align.Auto,
                              string textColorHex = "#FFFFFF", string backgroundColorHex = "#a5a5a5")
        {
            this.titleText = titleText;
            this.fontSize = fontSize;
            this.alignment = alignment;

            textColor = ColorUtility.TryParseHtmlString(textColorHex, out Color texColor) ? texColor : Color.white;
            backgroundColor = ColorUtility.TryParseHtmlString(backgroundColorHex, out Color bgColor) ? bgColor : Color.red;
        }
    }
}