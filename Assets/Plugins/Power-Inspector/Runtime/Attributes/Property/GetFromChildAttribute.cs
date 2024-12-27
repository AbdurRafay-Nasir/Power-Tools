using System;

namespace PowerEditor.Attributes
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