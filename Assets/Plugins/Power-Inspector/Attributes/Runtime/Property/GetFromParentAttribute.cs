using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromParentAttribute : PropertyAttribute
    {
        public bool searchAllPredecessors;

        public GetFromParentAttribute(bool searchAllPredecessors = false)
        {
            this.searchAllPredecessors = searchAllPredecessors;
        }
    }
}