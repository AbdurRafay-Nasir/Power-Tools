using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CommentAttribute : InspectorAttribute
{
    public string comment;

    public CommentAttribute(string comment)
    {
        this.comment = comment;
    }
}
