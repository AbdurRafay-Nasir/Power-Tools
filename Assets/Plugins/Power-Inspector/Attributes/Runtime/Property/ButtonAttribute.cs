using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ButtonAttribute : UnityEngine.PropertyAttribute
    {
        public string text;

        public ButtonAttribute(string buttonText)
        {
            text = buttonText;
        }
    }
}