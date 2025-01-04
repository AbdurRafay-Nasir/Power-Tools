using System;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public VisualElement CreateGroupGUI(in VisualElement parent)
        {
            VisualElement root = new VisualElement();

            root.SetEnabled(false);

            return root;
        }
    }
}