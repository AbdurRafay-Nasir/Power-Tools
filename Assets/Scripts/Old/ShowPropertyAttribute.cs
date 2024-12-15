using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class ShowPropertyAttribute : SinglePropertyAttribute
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        VisualElement element = new VisualElement();

        PropertyField propertyField = new PropertyField(property);
        propertyField.style.borderBottomLeftRadius = 5f;
        propertyField.style.borderBottomRightRadius = 5f;
        propertyField.style.borderTopLeftRadius = 5f;
        propertyField.style.borderTopRightRadius = 5f;

        propertyField.style.backgroundColor = Color.red;
        propertyField.style.paddingRight = new StyleLength(new Length(5f));

        element.Add(propertyField);

        return element;
    }
}
