using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpboxAttribute : PropertyAttribute
    {
        public string message;
        public HelpBoxMessageType messageType;

        public HelpboxAttribute(string message, HelpBoxMessageType messageType)
        {
            this.message = message;
            this.messageType = messageType;
        }
    }
}
