using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpboxAttribute : PowerAttribute
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
