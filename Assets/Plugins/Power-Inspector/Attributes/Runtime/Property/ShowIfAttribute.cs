using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfAttribute : UnityEngine.PropertyAttribute
    {
        public string expression;

        public ShowIfAttribute(string expression)
        {
            this.expression = expression;
        }
    }
}