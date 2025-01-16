using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromChildAttribute : UnityEngine.PropertyAttribute
    {
        public bool SearchAllSuccessors { get; }

        public GetFromChildAttribute(bool searchAllSuccessors = false)
        {
            SearchAllSuccessors = searchAllSuccessors;
        }
    }
}