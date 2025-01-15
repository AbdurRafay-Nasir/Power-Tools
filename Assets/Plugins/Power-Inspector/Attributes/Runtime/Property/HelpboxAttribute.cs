using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpboxAttribute : UnityEngine.PropertyAttribute
    {
        public string Message { get; }
        public MessageType MessageType { get; }

        public HelpboxAttribute(string message, MessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }
}
