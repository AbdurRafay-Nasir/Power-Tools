using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromSelfAttribute : InspectorAttribute
    {
        public GetFromSelfAttribute()
        {
            
        }
    }
}