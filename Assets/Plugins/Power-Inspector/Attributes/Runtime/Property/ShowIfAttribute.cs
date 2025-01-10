using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfAttribute : PowerAttribute
    {
        public string expression;

        public ShowIfAttribute(string expression)
        {
            this.expression = expression;
        }
    }
}