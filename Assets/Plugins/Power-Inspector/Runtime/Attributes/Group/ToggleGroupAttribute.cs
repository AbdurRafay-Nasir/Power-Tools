using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ToggleGroupAttribute : PowerAttribute
    {
        public string toggleName;

        public ToggleGroupAttribute(string toggleName)
        {
            this.toggleName = toggleName;
        }
    }
}