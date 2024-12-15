using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyAttributeDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        VisualElement root = new VisualElement();

        PropertyField propertyField = new PropertyField(property);
        HelpBox helpBox = new HelpBox("AAAA", HelpBoxMessageType.Error);

        propertyField.RegisterValueChangeCallback(callback =>
        {
            if (property.intValue < 0f)
            {
                if (!root.Contains(helpBox))
                    root.Add(helpBox);
            }
            else
            {
                if (root.Contains(helpBox))
                    root.Remove(helpBox);
            }
        });

        root.Add(propertyField);

        return root;
    }
}