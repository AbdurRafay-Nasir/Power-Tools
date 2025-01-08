using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromSelfAttribute : PropertyAttribute
    {
        public GetFromSelfAttribute()
        {
            
        }
    }
}