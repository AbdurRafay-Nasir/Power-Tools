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
            Color lightWhite = new Color(0.7f, 0.7f, 0.7f);

            VisualElement root = new VisualElement();
            root.SetPadding(attr.PaddingLeft, attr.PaddingRight, attr.PaddingTop, attr.PaddingBottom);
            root.SetMargin(attr.MarginLeft, attr.MarginRight, attr.MarginTop, attr.MarginBottom);

            Label title = new Label(attr.Title);
            title.style.alignSelf = (Align)(int)attr.TitleAlignment;
            title.style.unityFontStyleAndWeight = attr.BoldTitle ? FontStyle.Bold : FontStyle.Normal;
            title.style.fontSize = attr.TitleFontSize;
            title.style.paddingBottom = 1f;
            title.style.whiteSpace = WhiteSpace.Normal;
            title.style.overflow = Overflow.Visible;

            root.Add(title);

            if (!string.IsNullOrEmpty(attr.Description))
            {
                Label description = new Label(attr.Description);
                description.style.color = lightWhite;
                description.style.alignSelf = (Align)(int)attr.DescriptionAlignment;
                description.style.fontSize = attr.DescriptionFontSize;
                description.style.paddingBottom = 2f;
                description.style.whiteSpace = WhiteSpace.Normal;
                description.style.overflow = Overflow.Visible;

                root.Add(description);
            }

            if (attr.AddHorizontalLine)
            {
                VisualElement horizontalLine = new VisualElement();
                horizontalLine.style.backgroundColor = lightWhite;
                horizontalLine.style.height = 2;
                horizontalLine.style.marginBottom = 5f;
            
                root.Add(horizontalLine);
            }

            return root;
        }
    }
}

#endif
