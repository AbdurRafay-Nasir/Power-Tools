using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(RequiredAttribute))]
    public class RequiredAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new();

            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                root.Add(new HelpBox(property.name + " is not an Object Field", HelpBoxMessageType.Error));
                return root;
            }

            HelpBox helpbox = new HelpBox((attribute as RequiredAttribute).Message, HelpBoxMessageType.Error);
            helpbox.style.display = property.objectReferenceValue == null
                                    ? DisplayStyle.Flex
                                    : DisplayStyle.None;

            PropertyField propertyField = new PropertyField(property);

            propertyField.RegisterValueChangeCallback(callback =>
            {
                if (property.objectReferenceValue == null)
                {
                    helpbox.style.display = DisplayStyle.Flex;
                }
                else
                {
                    helpbox.style.display = DisplayStyle.None;
                }
            });

            root.Add(helpbox);
            root.Add(propertyField);

            return root;
        }

    }
}
