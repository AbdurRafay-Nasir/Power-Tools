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
            System.Delegate lambda;

            try
            {
                lambda = DynamicExpressionParser.ParseLambda(property.serializedObject.targetObject.GetType(),
                                                             typeof(bool), attr.expression).Compile();
            }
            catch (System.Exception e)
            {
                return new HelpBox("Error in expression on field: <color=yellow>" + 
                                    property.name + "</color> The problem is: \n<color=cyan>" + e.Message,
                                    HelpBoxMessageType.Error);
            }

            PropertyField propertyField = new PropertyField(property);

            bool result = (bool)lambda.DynamicInvoke(property.serializedObject.targetObject);
            propertyField.style.display = result ? DisplayStyle.Flex : DisplayStyle.None;
         
            propertyField.TrackSerializedObjectValue(property.serializedObject, ((_) =>
            {
                result = (bool)lambda.DynamicInvoke(property.serializedObject.targetObject);
                propertyField.style.display = result ? DisplayStyle.Flex : DisplayStyle.None;                
            }));

            return propertyField;
        }
    }
}

#endif