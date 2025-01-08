using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string text;

        public ButtonAttribute(string buttonText)
        {
            text = buttonText;
        }
    }
}