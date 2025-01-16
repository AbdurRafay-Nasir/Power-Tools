using UnityEngine;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{ 
    public static class VisualElementExtensions
    {
        #region Paddin Functions

        public static void SetPadding(this VisualElement v, float padding)
        {
            v.style.paddingLeft = padding;
            v.style.paddingRight = padding;
            v.style.paddingTop = padding;
            v.style.paddingBottom = padding;
        }
        public static void SetPadding(this VisualElement v, float horizontal, float vertical)
        {
            v.style.paddingLeft = horizontal;
            v.style.paddingRight = horizontal;
            v.style.paddingTop = vertical;
            v.style.paddingBottom = vertical;
        }
        public static void SetPadding(this VisualElement v, float left, float right, float top, float bottom)
        {
            v.style.paddingLeft = left;
            v.style.paddingRight = right;
            v.style.paddingTop = top;
            v.style.paddingBottom = bottom;
        }

        #endregion

        #region Margin Functions

        public static void SetMargin(this VisualElement v, float margin)
        {
            v.style.marginLeft = margin;
            v.style.marginRight = margin;
            v.style.marginTop = margin;
            v.style.marginBottom = margin;
        }
        public static void SetMargin(this VisualElement v, float horizontal, float vertical)
        {
            v.style.marginLeft = horizontal;
            v.style.marginRight = horizontal;
            v.style.marginTop = vertical;
            v.style.marginBottom = vertical;
        }
        public static void SetMargin(this VisualElement v, float left, float right, float top, float bottom)
        {
            v.style.marginLeft = left;
            v.style.marginRight = right;
            v.style.marginTop = top;
            v.style.marginBottom = bottom;
        }

        #endregion

        #region Border Radius Functions

        public static void SetBorderRadius(this VisualElement v, float radius)
        {
            v.style.borderTopLeftRadius = radius;
            v.style.borderTopRightRadius = radius;
            v.style.borderBottomLeftRadius = radius;
            v.style.borderBottomRightRadius = radius;
        }
        public static void SetBorderRadius(this VisualElement v, float topLeft, float topRight,
                                           float bottomLeft, float bottomRight)
        {
            v.style.borderTopLeftRadius = topLeft;
            v.style.borderTopRightRadius = topRight;
            v.style.borderBottomLeftRadius = bottomLeft;
            v.style.borderBottomRightRadius = bottomRight;
        }

        #endregion

        #region Border Width Functions

        public static void SetBorderWidth(this VisualElement v, float width)
        {
            v.style.borderLeftWidth = width;
            v.style.borderRightWidth = width;
            v.style.borderTopWidth = width;
            v.style.borderBottomWidth = width;
        }
        public static void SetBorderWidth(this VisualElement v, float horizontal, float vertical)
        {
            v.style.borderLeftWidth = horizontal;
            v.style.borderRightWidth = horizontal;
            v.style.borderTopWidth = vertical;
            v.style.borderBottomWidth = vertical;
        }
        public static void SetBorderWidth(this VisualElement v, float left, float right, float top, float bottom)
        {
            v.style.borderLeftWidth = left;
            v.style.borderRightWidth = right;
            v.style.borderTopWidth = top;
            v.style.borderBottomWidth = bottom;
        }

        #endregion

        #region Border Color Functions

        public static void SetBorderColor(this VisualElement v, Color color)
        {
            v.style.borderLeftColor = color;
            v.style.borderRightColor = color;
            v.style.borderTopColor = color;
            v.style.borderBottomColor = color;
        }
        public static void SetBorderColor(this VisualElement v, Color leftRight, Color topBottom)
        {
            v.style.borderLeftColor = leftRight;
            v.style.borderRightColor = leftRight;
            v.style.borderTopColor = topBottom;
            v.style.borderBottomColor = topBottom;
        }
        public static void SetBorderColor(this VisualElement v, Color left, Color right, Color top, Color bottom)
        {
            v.style.borderLeftColor = left;
            v.style.borderRightColor = right;
            v.style.borderTopColor = top;
            v.style.borderBottomColor = bottom;
        }

        #endregion
    }
}
