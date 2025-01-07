using PowerEditor.Attributes.Editor;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BoxGroupAttribute : PowerAttribute, IGroupAttribute
    {
        private readonly Box box = new Box();

        public BoxGroupAttribute()
        {
            box.style.backgroundColor = new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderRadius(5f);
            box.SetBorderWidth(1f);
            box.SetBorderColor(new Color(0.5f, 0.5f, 0.5f));
        }
        public BoxGroupAttribute(float radius)
        {
            box.style.backgroundColor = new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderRadius(radius);
            box.SetBorderWidth(1f);
            box.SetBorderColor(new Color(0.5f, 0.5f, 0.5f));
        }
        public BoxGroupAttribute(string bgColor)
        {
            box.style.backgroundColor = ColorUtility.TryParseHtmlString(bgColor, out var color) ?
                                        color : new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderRadius(5f);
            box.SetBorderWidth(1f);
            box.SetBorderColor(new Color(0.5f, 0.5f, 0.5f));
        }
        public BoxGroupAttribute(float radius, float width)
        {
            box.style.backgroundColor = new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderRadius(radius);
            box.SetBorderWidth(width);
            box.SetBorderColor(new Color(0.5f, 0.5f, 0.5f));
        }
        public BoxGroupAttribute(float radius, float width, string borderColor)
        {
            box.style.backgroundColor = new Color(0.19f, 0.19f, 0.19f);

            box.SetBorderRadius(radius);
            box.SetBorderWidth(width);

            Color color = ColorUtility.TryParseHtmlString(borderColor, out var bordColor) ?
                          bordColor : new Color(0.19f, 0.19f, 0.19f);
            box.SetBorderColor(color);
        }
        public BoxGroupAttribute(float radius, float width,
                                 string borderColor, string bgColor)
        {

            box.style.backgroundColor = ColorUtility.TryParseHtmlString(bgColor, out var color) ?
                                        color : new Color(0.19f, 0.19f, 0.19f);

            Color bdColor = ColorUtility.TryParseHtmlString(borderColor, out var bordColor) ?
                            bordColor : new Color(0.5f, 0.5f, 0.5f);
            box.SetBorderColor(bdColor);

            box.SetBorderRadius(radius);
            box.SetBorderWidth(width);
        }

        public VisualElement CreateGroupGUI()
        {
            box.SetPadding(0f, 2f, 2f, 2f);

            return box;
        }
    }
}
