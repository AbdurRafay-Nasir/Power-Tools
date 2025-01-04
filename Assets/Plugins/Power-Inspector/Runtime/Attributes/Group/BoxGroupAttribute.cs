using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BoxGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public readonly Color backgroundColor;
        public readonly float borderRadius;
        public readonly float borderWidth;
        public readonly Color borderColor;

        public BoxGroupAttribute(string backgroundColor = "#303030", float borderRadius = 5f, 
                                 float borderWidth = 1f, string borderColor = "#808080")
        {
            this.backgroundColor = ColorUtility.TryParseHtmlString(backgroundColor, out var bgColor) ? 
                                   bgColor : new Color(0.19f, 0.19f, 0.19f);

            this.borderRadius = borderRadius;
            this.borderWidth = borderWidth;

            this.borderColor = ColorUtility.TryParseHtmlString(borderColor, out var bordColor) ?
                               bordColor : new Color(0.19f, 0.19f, 0.19f);
        }

        public VisualElement CreateGroupGUI(in VisualElement parent)
        {
            Box box = new Box();

            box.style.backgroundColor = backgroundColor;

            box.style.borderBottomLeftRadius = borderRadius;
            box.style.borderBottomRightRadius = borderRadius;
            box.style.borderTopLeftRadius = borderRadius;
            box.style.borderTopRightRadius = borderRadius;

            box.style.borderLeftWidth = borderWidth;
            box.style.borderRightWidth = borderWidth;
            box.style.borderTopWidth = borderWidth;
            box.style.borderBottomWidth = borderWidth;

            box.style.borderRightColor = borderColor;
            box.style.borderLeftColor = borderColor;
            box.style.borderTopColor = borderColor;
            box.style.borderBottomColor = borderColor;

            box.style.paddingTop = 2f;
            box.style.paddingRight = 2f;
            box.style.paddingBottom = 2f;

            return box;
        }
    }
}
