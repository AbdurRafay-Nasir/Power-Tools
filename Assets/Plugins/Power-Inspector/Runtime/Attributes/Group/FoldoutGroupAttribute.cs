using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FoldoutGroupAttribute : PowerAttribute, IGroupAttribute
    {
        public string name;
        public bool open;

        public FoldoutGroupAttribute(string name = "", bool open = false)
        {
            this.name = name;
            this.open = open;
        }

        public VisualElement CreateGroupGUI()
        {
            Foldout foldout = new Foldout();
            foldout.AddToClassList("unity-list-view__foldout-header");

            foldout.text = name;
            foldout.value = open;

            return foldout;
        }
    }
}