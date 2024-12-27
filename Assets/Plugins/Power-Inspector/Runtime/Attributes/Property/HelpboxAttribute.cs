using System;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpboxAttribute : PowerAttribute
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
