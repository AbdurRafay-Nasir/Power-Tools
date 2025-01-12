using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BoxGroupAttribute : PropertyAttribute, IGroupAttribute, IPaddingMargin
    {
        public string BorderColorHex { get; set; } = "#808080";
        public string BgColorHex { get; set; } = "#303030";
        public float Radius { get; set; } = 5f;
        public float Width { get; set; } = 1f;

        public float PaddingLeft { get; set; }
        public float PaddingRight { get; set; } = 2f;
        public float PaddingTop { get; set; } = 2f;
        public float PaddingBottom { get; set; } = 2f;
        public float MarginLeft { get; set; }
        public float MarginRight { get; set; }
        public float MarginTop { get; set; }
        public float MarginBottom { get; set; }

        public VisualElement CreateGroupGUI()
        {
            Box box = new Box();

            box.style.backgroundColor = ColorUtility.TryParseHtmlString(BgColorHex, out var color) ?
                                        color : new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderColor(ColorUtility.TryParseHtmlString(BorderColorHex, out var bordColor) ?
                               bordColor : new Color(0.19f, 0.19f, 0.19f));

            box.SetBorderRadius(Radius);
            box.SetBorderWidth(Width);
            box.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            box.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return box;
        }
    }
}
