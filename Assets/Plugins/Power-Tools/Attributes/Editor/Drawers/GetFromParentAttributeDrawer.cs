#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(GetFromParentAttribute))]
    public class GetFromParentAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            GetFromParentAttribute attr = (attribute as GetFromParentAttribute);

            VisualElement root = new VisualElement();

            // Ensure the Property is Object Reference. Not allow int, float, bool, string etc
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                root.Add(new HelpBox("<color=green>[GetFromParent]</color> is only valid on Object Reference. ", HelpBoxMessageType.Error));
                return root;
            }

            // Ensure Field is a Component. Not allow references such as: Sprite, Texture etc
            if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            {
                root.Add(new HelpBox("<color=green>[GetFromParent]</color> is only valid for Component Reference. ", HelpBoxMessageType.Error));
                return root;
            }

            // Ensure Property is null, before filling it
            if (property.objectReferenceValue == null)
            {
                Transform transform = (property.serializedObject.targetObject as Component).transform;

                if (transform.parent == null)
                {
                    root.Add(new HelpBox("GameObject: <color=yellow>" + transform.name + "</color> does not have a parent", HelpBoxMessageType.Error));
                    return root;
                }

                Transform currentParent = transform.parent;
                Component component = null;

                while (currentParent != null)
                {
                    if (currentParent.TryGetComponent(fieldInfo.FieldType, out var comp))
                    {
                        component = comp;
                        break;
                    }

                    currentParent = attr.SearchAllPredecessors ? currentParent.parent : null;
                }

                if (component != null)
                {
                    property.objectReferenceValue = component;
                    property.serializedObject.ApplyModifiedProperties();
                }
                else
                {
                    root.Add(new HelpBox(fieldInfo.FieldType + " Component does not exist on any parent", 
                                         HelpBoxMessageType.Error));
                }
            }

            root.Add(new PropertyField(property));

            return root;
        }
    }
}

#endif