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

            HelpBox helpbox = new HelpBox((attribute as RequiredAttribute).message, HelpBoxMessageType.Error);
            PropertyField propertyField = new PropertyField(property);

            propertyField.RegisterValueChangeCallback(callback =>
            {
                if (property.objectReferenceValue == null)
                {
                    root.Insert(0, helpbox);
                }
                else
                {
                    if (root.Contains(helpbox))
                        root.Remove(helpbox);
                }
            });

            root.Add(propertyField);

            return root;
        }

    }
}
