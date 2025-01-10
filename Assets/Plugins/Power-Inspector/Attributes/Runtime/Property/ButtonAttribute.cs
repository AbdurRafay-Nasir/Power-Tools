using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ButtonAttribute : PowerAttribute
    {
        public string text;

        public ButtonAttribute(string buttonText)
        {
            text = buttonText;
        }
    }
}