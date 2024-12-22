using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CommentAttribute : InspectorAttribute
    {
        public string comment;

        public CommentAttribute(string comment)
        {
            this.comment = comment;
        }
    }
}
