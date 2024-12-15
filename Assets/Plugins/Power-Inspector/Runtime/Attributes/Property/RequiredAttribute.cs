using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class RequiredAttribute : InspectorAttribute
{
    public string text;

    public RequiredAttribute(string text)
    {
        this.text = text;
    }
}
