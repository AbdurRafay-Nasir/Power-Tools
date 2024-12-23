#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(HelpboxAttribute))]
    public class HelpboxAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            HelpboxAttribute attr = (attribute as HelpboxAttribute);

            VisualElement root = new VisualElement();
            root.Add(new HelpBox(attr.message, attr.messageType));
            root.Add(new PropertyField(property));

            return root;
        }
    }
}

#endif