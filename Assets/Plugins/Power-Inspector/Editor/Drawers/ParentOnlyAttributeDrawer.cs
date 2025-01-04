#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(ParentOnlyAttribute))]
    public class ParentOnlyAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                return new HelpBox("<color=green>[ParentOnly]</color> is valid on Object Reference.", HelpBoxMessageType.Error);
            }

            VisualElement root = new VisualElement();

           

            return root;
        }
    }
}

#endif