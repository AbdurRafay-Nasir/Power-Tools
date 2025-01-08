#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace PowerTools.Attributes.Editor
{ 
    [CustomPropertyDrawer(typeof(TitleAttribute))]
    public class TitleAttributeDrawer : DecoratorDrawer
    {
        public override VisualElement CreatePropertyGUI()
        {
            TitleAttribute attr = (attribute as TitleAttribute);
            VisualElement root = new VisualElement();
            Color lightWhite = new Color(0.6509f, 0.6509f, 0.6509f, 1f);

            Label title = new Label(attr.title);
            // title.style.alignSelf = (Align)(int)attr.alignment;
            title.style.unityFontStyleAndWeight = attr.boldTitle ? FontStyle.Bold : FontStyle.Normal;
            title.style.fontSize = attr.titleFontSize;
            title.style.paddingBottom = 1f;
            title.style.whiteSpace = WhiteSpace.Normal;
            title.style.overflow = Overflow.Visible;

            Label description = new Label(attr.description);
            description.style.color = lightWhite;
            // description.style.alignSelf = (Align)(int)attr.alignment;
            description.style.fontSize = attr.titleFontSize * 0.75f; // Two Third
            description.style.paddingBottom = 2f;
            description.style.whiteSpace = WhiteSpace.Normal;
            description.style.overflow = Overflow.Visible;

            VisualElement horizontalLine = new VisualElement();
            horizontalLine.style.backgroundColor = lightWhite;
            horizontalLine.style.height = 2;
            horizontalLine.style.marginBottom = 5f;
            horizontalLine.style.width = Length.Percent(100);

            root.Add(title);
            root.Add(description);
            root.Add(horizontalLine);

            return root;
        }
    }
}

#endif
