using System;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromParentAttribute : PowerAttribute
    {
        public bool searchAllPredecessors;

        public GetFromParentAttribute(bool searchAllPredecessors = false)
        {
            this.searchAllPredecessors = searchAllPredecessors;
        }
    }
}