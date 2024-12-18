using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredAttribute : InspectorAttribute
    {
        public string message;

        public RequiredAttribute(string message)
        {
            this.message = message;
        }
    }
}