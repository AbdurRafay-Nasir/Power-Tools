using System;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EndGroupAttribute : PropertyAttribute
    {
        public int openGroupsToClose;

        public EndGroupAttribute(int openGroupsToClose = 1)
        {
            if (openGroupsToClose < 1)
                openGroupsToClose = 1;

            this.openGroupsToClose = openGroupsToClose;
        }
    }
}
