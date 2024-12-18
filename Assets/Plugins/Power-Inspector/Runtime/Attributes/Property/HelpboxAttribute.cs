using System;
using UnityEngine.UIElements;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpboxAttribute : InspectorAttribute, IGroupAttribute
    {
        public VisualElement CreateGroupGUI()
        {
            VisualElement gui = new VisualElement();

            gui.Add(new HelpBox("HOLA AMIGO", HelpBoxMessageType.Error));

            return gui;
        }
    }
}
