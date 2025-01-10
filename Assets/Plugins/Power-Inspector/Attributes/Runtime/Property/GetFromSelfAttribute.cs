using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromSelfAttribute : PowerAttribute
    {
        public GetFromSelfAttribute()
        {
            
        }
    }
}