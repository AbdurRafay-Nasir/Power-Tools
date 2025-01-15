using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromChildAttribute : PowerAttribute
    {
        public bool searchAllSuccessors;

        public GetFromChildAttribute(bool searchAllSuccessors = false)
        {
            this.searchAllSuccessors = searchAllSuccessors;
        }
    }
}