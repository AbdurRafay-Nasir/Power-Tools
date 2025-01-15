using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromParentAttribute : UnityEngine.PropertyAttribute
    {
        public bool SearchAllPredecessors { get; }

        public GetFromParentAttribute(bool searchAllPredecessors = false)
        {
            SearchAllPredecessors = searchAllPredecessors;
        }
    }
}