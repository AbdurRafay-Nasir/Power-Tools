using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredAttribute : PropertyAttribute
    {
        public string message;

        public RequiredAttribute(string message = "This is Required")
        {
            this.message = message;
        }
    }
}