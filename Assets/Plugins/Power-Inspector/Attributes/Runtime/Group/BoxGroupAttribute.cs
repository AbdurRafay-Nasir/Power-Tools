using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BoxGroupAttribute : PropertyAttribute, IGroupAttribute
    {
        #region Padding

        public float PaddingLeft { get; set; }
        public float PaddingRight { get; set; } = 2f;
        public float PaddingTop { get; set; } = 2f;
        public float PaddingBottom { get; set; } = 2f;
        public float PaddingHorizontal
        {
            get => 0f;
            set
            {
                PaddingLeft = value;
                PaddingRight = value;
            }
        }
        public float PaddingVertical
        {
            get => 0f;
            set
            {
                PaddingTop = value;
                PaddingBottom = value;
            }
        }
        public float Padding
        {
            get => 0f;
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
            get => 0f;
            set
            {
                MarginLeft = value;
                MarginRight = value;
            }
        }
        public float MarginVertical
        {
            get => 0f;
            set
            {
                MarginTop = value;
                MarginBottom = value;
            }
        }
        public float Margin
        {

            get => 0f;
            set
            {
                MarginLeft = value;
                MarginRight = value;
                MarginTop = value;
                MarginBottom = value;
            }
        }

        #endregion

        #region Border Color

        public string BorderColorLeftHex { get; set; } = "#808080";
        public string BorderColorRightHex { get; set; } = "#808080";
        public string BorderColorTopHex { get; set; } = "#808080";
        public string BorderColorBottomHex { get; set; } = "#808080";
        public string BorderColorHorizontalHex
        {
            set
            {
                BorderColorLeftHex = value;
                BorderColorRightHex = value;
            }
        }
        public string BorderColorVerticalHex
        {
            set
            {
                BorderColorTopHex = value;
                BorderColorBottomHex = value;
            }
        }
        public string BorderColorHex
        {
            set
            {
                BorderColorLeftHex = value;
                BorderColorRightHex = value;
                BorderColorTopHex = value;
                BorderColorBottomHex = value;
            }
        }

        #endregion

        #region Border Radius

        public float BorderRadiusTopLeft { get; set; } = 5f;
        public float BorderRadiusTopRight { get; set; } = 5f;
        public float BorderRadiusBottomLeft { get; set; } = 5f;
        public float BorderRadiusBottomRight { get; set; } = 5f;
        public float BorderRadiusTop
        {
            get => 0f; set
            {
                BorderRadiusTopLeft = value;
                BorderRadiusTopRight = value;
            }
        }
        public float BorderRadiusBottom
        {
            get => 0f; 
            set
            {
                BorderRadiusBottomLeft = value;
                BorderRadiusBottomRight = value;
            }
        }
        public float BorderRadius
        {
            get => 0f;
            set
            {
                BorderRadiusTopLeft = value;
                BorderRadiusTopRight = value;
                BorderRadiusBottomLeft = value;
                BorderRadiusBottomRight = value;
            }
        }

        #endregion

        #region Border Width

        public float BorderWidthLeft { get; set; } = 1f;
        public float BorderWidthRight { get; set; } = 1f;
        public float BorderWidthTop { get; set; } = 1f;
        public float BorderWidthBottom { get; set; } = 1f;
        public float BorderWidthHorizontal
        {
            get => 0f; 
            set
            {
                BorderWidthLeft = value;
                BorderWidthRight = value;
            }
        }
        public float BorderWidthVertical
        {
            get => 0f; 
            set
            {
                BorderWidthTop = value;
                BorderWidthBottom = value;
            }
        }
        public float BorderWidth
        {
            get => 0f; 
            set
            {
                BorderWidthLeft = value;
                BorderWidthRight = value;
                BorderWidthTop = value;
                BorderWidthBottom = value;
            }
        }

        #endregion

        public string BgColorHex { get; set; } = "#303030";

        public VisualElement CreateGroupGUI()
        {
            Box box = new Box();

            box.style.backgroundColor = ColorUtility.TryParseHtmlString(BgColorHex, out var color) ?
                                        color : new Color(0.19f, 0.19f, 0.19f);

            Color borderLeftColor = ColorUtility.TryParseHtmlString(BorderColorLeftHex, out var left)
                                   ? left
                                   : new Color(0.19f, 0.19f, 0.19f);

            Color borderRightColor = ColorUtility.TryParseHtmlString(BorderColorRightHex, out var right)
                                   ? right
                                   : new Color(0.19f, 0.19f, 0.19f);

            Color borderTopColor = ColorUtility.TryParseHtmlString(BorderColorTopHex, out var top)
                                   ? top
                                   : new Color(0.19f, 0.19f, 0.19f);

            Color borderBottomColor = ColorUtility.TryParseHtmlString(BorderColorBottomHex, out var bottom)
                                    ? bottom
                                    : new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderColor(borderLeftColor, borderRightColor, borderTopColor, borderBottomColor);

            box.SetBorderRadius(BorderRadiusTopLeft, BorderRadiusTopRight,
                                BorderRadiusBottomLeft, BorderRadiusBottomRight);

            box.SetBorderWidth(BorderWidthLeft, BorderWidthRight, BorderWidthTop, BorderWidthBottom);
            box.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            box.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return box;
        }
    }
}
