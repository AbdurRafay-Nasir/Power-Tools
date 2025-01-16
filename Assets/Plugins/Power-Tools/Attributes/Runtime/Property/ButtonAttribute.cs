using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ButtonAttribute : UnityEngine.PropertyAttribute
    {
        public string Text { get; }

        public ButtonAttribute(string buttonText)
        {
            Text = buttonText;
        }
    }
}