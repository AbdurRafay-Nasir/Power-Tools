using System;
using UnityEngine.UIElements;
using PowerEditor.Attributes.Editor;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public VisualElement CreateGroupGUI()
        {
            VisualElement root = new VisualElement();

            root.SetEnabled(false);

            root.SetPadding(PaddingLeft, PaddingRight, PaddingTop, PaddingBottom);
            root.SetMargin(MarginLeft, MarginRight, MarginTop, MarginBottom);

            return root;
        }
    }
}