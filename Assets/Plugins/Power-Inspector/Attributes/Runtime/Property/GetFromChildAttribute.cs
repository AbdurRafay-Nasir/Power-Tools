using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GetFromChildAttribute : PropertyAttribute
    {
        public bool searchAllSuccessors;

        public GetFromChildAttribute(bool searchAllSuccessors = false)
        {
            this.searchAllSuccessors = searchAllSuccessors;
        }
    }
}