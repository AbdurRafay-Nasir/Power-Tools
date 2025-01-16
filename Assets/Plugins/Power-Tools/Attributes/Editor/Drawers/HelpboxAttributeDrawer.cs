#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(HelpboxAttribute))]
    public class HelpboxAttributeDrawer : DecoratorDrawer
    {
        public override VisualElement CreatePropertyGUI()
        {
            HelpboxAttribute attr = (attribute as HelpboxAttribute);

            return new HelpBox(attr.Message, (HelpBoxMessageType)(int)attr.MessageType);
        }
    }
}

#endif