#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(FolderPathAttribute))]
    public class FolderPathAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                return new HelpBox("<color=green>[FolderPath]</color> is applicable only on String Fields", HelpBoxMessageType.Error);
            }

            ObjectField objectField = new ObjectField("WWWWWWWWWW");

            // For whatever reason the field where object is assigned is too long
            // Therefore adding some margin to label
            objectField.Q<Label>().style.marginRight = 15f;

            objectField.RegisterValueChangedCallback((callback) =>
            {
                if (objectField.value != null)
                {
                    if (AssetDatabase.Contains(objectField.value))
                    {
                        string path = AssetDatabase.GetAssetPath(objectField.value);
                        if (AssetDatabase.IsValidFolder(path))
                        {
                            property.stringValue = path;
                            property.serializedObject.ApplyModifiedProperties();
                        }
                        else
                        {
                            objectField.value = null;
                        }
                    }
                }
            });

            return objectField;
        }
    }
}

#endif