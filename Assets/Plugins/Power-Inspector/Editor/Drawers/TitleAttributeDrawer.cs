using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(TitleAttribute))]
public class TitleAttributeDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        TitleAttribute attr = (attribute as TitleAttribute);

        VisualElement root = new();

        Box box = new Box();
        box.style.backgroundColor = attr.backgroundColor;

        Label label = new Label(attr.titleText);
        label.style.alignSelf = attr.alignment;
        label.style.fontSize = attr.fontSize;
        label.style.color = attr.textColor;

        box.Add(label);
        root.Add(box);
        root.Add(new PropertyField(property));

        return root;
    }
}
