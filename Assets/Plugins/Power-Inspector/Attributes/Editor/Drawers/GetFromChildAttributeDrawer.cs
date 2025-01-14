#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(GetFromChildAttribute))]
    public class GetFromChildAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            GetFromChildAttribute attr = (attribute as GetFromChildAttribute);

            VisualElement root = new VisualElement();

            // Ensure the Property is Object Reference. Not allow int, float, bool, string etc
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                root.Add(new HelpBox("GetFromChildAttribute: is only valid on Object Reference. ", HelpBoxMessageType.Error));
                return root;
            }

            // Ensure Field is a Component. Don't allow references such as: Sprite, Texture etc
            if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            {
                root.Add(new HelpBox("GetFromChildAttribute: is only valid on Component Reference. ", HelpBoxMessageType.Error));
                return root;
            }

            // Ensure Property is null, before filling it
            if (property.objectReferenceValue == null)
            {
                Transform transform = (property.serializedObject.targetObject as Component).transform;

                if (transform.childCount == 0)
                {
                    root.Add(new HelpBox(transform.name + " does not have any child", HelpBoxMessageType.Error));
                    return root;
                }

                if (attr.searchAllSuccessors)
                {
                    SearchAllChilds(property, transform, root);
                }
                else
                {
                    SearchDirectChilds(property, transform, root);
                }
            }

            root.Add(new PropertyField(property));

            return root;
        }

        private void SearchDirectChilds(SerializedProperty property, Transform transform, VisualElement root)
        {
            Component comp = null;

            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(fieldInfo.FieldType, out var component))
                {
                    comp = component;
                    break;
                }
            }

            if (comp != null)
            {
                property.objectReferenceValue = comp;
                property.serializedObject.ApplyModifiedProperties();
            }
            else
            {
                root.Add(new HelpBox(fieldInfo.FieldType + " Component does not exist on direct Childs",
                                     HelpBoxMessageType.Error));
            }
        }

        private void SearchAllChilds(SerializedProperty property, Transform transform, VisualElement root)
        {
            Transform[] childs = transform.GetComponentsInChildren<Transform>();
            Component comp = null;

            // First element is Self Transform
            for (int i = 1; i < childs.Length; i++)
            {
                if (childs[i].TryGetComponent(fieldInfo.FieldType, out var component))
                {
                    comp = component;
                    break;
                }
            }

            if (comp != null)
            {
                property.objectReferenceValue = comp;
                property.serializedObject.ApplyModifiedProperties();
            }
            else
            {
                root.Add(new HelpBox(fieldInfo.FieldType + " Component does not exist on All Childs",
                                     HelpBoxMessageType.Error));
            }
        }
    }
}

#endif