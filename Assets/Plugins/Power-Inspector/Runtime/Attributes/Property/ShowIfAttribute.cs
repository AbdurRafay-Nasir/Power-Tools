using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ShowIfAttribute : PowerAttribute
    {
        public string expression;

        public ShowIfAttribute(string expression)
        {
            this.expression = expression;
        }
    }
}