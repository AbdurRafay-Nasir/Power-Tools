using System;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FoldoutGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public VisualElement CreateGroupGUI()
        {
            Foldout foldout = new Foldout();
            foldout.text = "F1";

            foldout.viewDataKey = "AAA";

            return foldout;
        }
    }

}