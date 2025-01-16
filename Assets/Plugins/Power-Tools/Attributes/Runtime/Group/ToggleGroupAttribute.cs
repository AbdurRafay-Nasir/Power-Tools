using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ToggleGroupAttribute : UnityEngine.PropertyAttribute
    {
        public string ToggleName { get; }

        public ToggleGroupAttribute(string toggleName)
        {
            ToggleName = toggleName;
        }
    }
}