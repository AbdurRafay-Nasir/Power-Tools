#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using System.Linq.Dynamic.Core;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            ShowIfAttribute attr = (attribute as ShowIfAttribute);

            System.Delegate compiledLambda = DynamicExpressionParser
                                           .ParseLambda(property.serializedObject.targetObject.GetType(), 
                                                        typeof(bool), attr.expression)
                                           .Compile();

            bool result = (bool)compiledLambda.DynamicInvoke(property.serializedObject.targetObject);

            PropertyField propertyField = new PropertyField(property);
            propertyField.style.display = result ? DisplayStyle.Flex : DisplayStyle.None;

            propertyField.RegisterValueChangeCallback((callback) =>
            {
                propertyField.style.display = result ? DisplayStyle.Flex : DisplayStyle.None;
            });

            return propertyField;
        }
    }
}

#endif