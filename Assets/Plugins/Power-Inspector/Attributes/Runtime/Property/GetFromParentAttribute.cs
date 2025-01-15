using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromParentAttribute : UnityEngine.PropertyAttribute
    {
        public readonly bool searchAllPredecessors;

        public GetFromParentAttribute(bool searchAllPredecessors = false)
        {
            this.searchAllPredecessors = searchAllPredecessors;
        }
    }
}