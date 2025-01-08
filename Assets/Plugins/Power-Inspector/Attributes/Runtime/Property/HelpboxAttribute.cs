using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpboxAttribute : PropertyAttribute
    {
        public string message;
        public MessageType messageType;

        public HelpboxAttribute(string message, MessageType messageType)
        {
            this.message = message;
            this.messageType = messageType;
        }
    }
}
