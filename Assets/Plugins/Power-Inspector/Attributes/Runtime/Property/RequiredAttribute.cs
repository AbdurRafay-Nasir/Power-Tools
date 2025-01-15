using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredAttribute : UnityEngine.PropertyAttribute
    {
        public string message;

        public RequiredAttribute(string message = "This is Required")
        {
            this.message = message;
        }
    }
}