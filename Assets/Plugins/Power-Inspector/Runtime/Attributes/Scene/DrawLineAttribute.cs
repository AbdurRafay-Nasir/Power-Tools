using System;
using UnityEngine;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DrawLineAttribute : PowerAttribute
    {
        public float lineThickness = 2f;
        public Color lineColor = Color.green;

        public DrawLineAttribute()
        {

        }

        public DrawLineAttribute(float lineThickness = 2f)
        {
            this.lineThickness = lineThickness < 0.5f ? 0.5f : lineThickness;
        }

        public DrawLineAttribute(string lineColor = "#00ff00")
        {
            if (ColorUtility.TryParseHtmlString(lineColor, out Color color))
            {
                this.lineColor = color;
            }
        }

        public DrawLineAttribute(float lineThickness = 2f, string lineColor = "#00ff00")
        {
            this.lineThickness = lineThickness < 0.5f ? 0.5f : lineThickness;

            if (ColorUtility.TryParseHtmlString(lineColor, out Color color))
            {
                this.lineColor = color;
            }
        }
    }
}