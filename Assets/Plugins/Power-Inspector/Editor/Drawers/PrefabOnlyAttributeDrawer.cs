#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(PrefabOnlyAttribute))]
    public class PrefabOnlyAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (fieldInfo.FieldType != typeof(GameObject))
            {
                return new HelpBox("<color=green>[PrefabOnly]</color> is applicable on GameObject reference only", HelpBoxMessageType.Error);
            }

            ObjectField objectField = new ObjectField(property.name);
            objectField.objectType = typeof(GameObject);
            objectField.allowSceneObjects = false;
            objectField.BindProperty(property);

            // By default unity adds this class on Child Fields of PropertyField
            // Since this field is added as a child of PropertyField through code
            // we need to add it manaully. 
            // NOTE - The root that we are returning will become child of PropertyField
            // which is Added in PowerInspectorEditor.cs. For more info refer to:
            // https://docs.unity3d.com/6000.0/Documentation/Manual/UIE-uxml-element-PropertyField.html#:~:text=Align%20a%20PropertyField,consistency%20and%20compatibility.
            objectField.AddToClassList("unity-base-field__aligned");

            return objectField;
        }
    }
}

#endif