using System;

namespace PowerTools.Attributes
{
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