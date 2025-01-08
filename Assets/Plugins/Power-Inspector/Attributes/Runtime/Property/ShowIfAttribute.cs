using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public string expression;

        public ShowIfAttribute(string expression)
        {
            this.expression = expression;
        }
    }
}