#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(GetFromSelfAttribute))]
    public class GetFromSelfAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            GetFromSelfAttribute attr = (attribute as GetFromSelfAttribute);

            VisualElement root = new VisualElement();

            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                root.Add(new HelpBox("GetFromSelfAttribute: is only valid on Object Reference. ", HelpBoxMessageType.Error));
                return root;
            }
            if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            {
                root.Add(new HelpBox("GetFromSelfAttribute: is only valid on Component Reference. ", HelpBoxMessageType.Error));
                return root;
            }
            if (property.objectReferenceValue == null)
            {
                GameObject targetGameObject = (property.serializedObject.targetObject as Component).gameObject;
                if (targetGameObject.TryGetComponent(fieldInfo.FieldType, out var comp))
                {
                    property.objectReferenceValue = comp;
                    property.serializedObject.ApplyModifiedProperties();
                }
                else
                {
                    root.Add(new HelpBox(fieldInfo.FieldType + " Component does not exist on " + 
                                         targetGameObject.name, HelpBoxMessageType.Error));
                }
            }

            root.Add(new PropertyField(property));
            return root;
        }
    }
}

#endif