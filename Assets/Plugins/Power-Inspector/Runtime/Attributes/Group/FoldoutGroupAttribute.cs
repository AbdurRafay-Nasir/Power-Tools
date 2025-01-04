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

        private Foldout foldout;
        private bool isExpanded = false;

        public FoldoutGroupAttribute(string name = "", bool open = false)
        {
            this.name = name;
            this.open = open;
        }

        public VisualElement CreateGroupGUI(in VisualElement parent)
        {
            foldout = new Foldout();
            foldout.AddToClassList("unity-list-view__foldout-header");

            foldout.text = name;
            foldout.value = open;

            //VisualElement content = foldout.Q<VisualElement>("unity-content");
            //Debug.Log(content.resolvedStyle.height);

            //foldout.RegisterValueChangedCallback(evt =>
            //{
            //    content.style.display = DisplayStyle.Flex;
            //    if (evt.newValue)
            //    {

            //        content.style.maxHeight = 0;
            //        content.experimental.animation.Start(0f, 100f, 300, (element, value) =>
            //        {
            //            element.style.maxHeight = new StyleLength(Length.Percent(value));
            //        });
            //    }
            //    else
            //    {
            //        // When closing, animate max-height to 0 and then set display to None
            //        content.experimental.animation.Start(100f, 0f, 300, (element, value) =>
            //        {
            //            element.style.maxHeight = new StyleLength(Length.Percent(value));
            //        }).OnCompleted(() =>
            //        {
            //            content.style.display = DisplayStyle.None;
            //        });
            //    }
            //});

            return foldout;
        }
    }
}