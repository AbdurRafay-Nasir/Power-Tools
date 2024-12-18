using System;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EndGroupAttribute : InspectorAttribute
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
