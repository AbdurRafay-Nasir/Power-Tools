#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerEditor.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(FilePathAttribute))]
    public class FilePathAttributeDrawer : PropertyDrawer, System.IDisposable
    {
        private SerializedProperty prop;
        private ObjectField objectField;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                return new HelpBox("<color=green>[FilePath]</color> is applicable only on String Fields", 
                                   HelpBoxMessageType.Error);
            }

            prop = property;

            Undo.undoRedoPerformed += OnUndoRedoPerformed;

            objectField = new ObjectField(property.name);
            objectField.allowSceneObjects = false;

            // For whatever reason the field where object is assigned is too long
            // Therefore adding some margin to label
            objectField.Q<Label>().style.marginRight = 15f;

            objectField.RegisterValueChangedCallback((callback) =>
            {
                if (objectField.value != null)
                {
                    string path = AssetDatabase.GetAssetPath(objectField.value);

                    if (AssetDatabase.IsValidFolder(path))
                    {
                        objectField.value = null;
                        return;
                    }
                    else
                    {
                        property.stringValue = path;
                        property.serializedObject.ApplyModifiedProperties();
                    }
                }
            });

            return objectField;
        }

        private void OnUndoRedoPerformed()
        {
            prop.serializedObject.Update();

            objectField.value = !string.IsNullOrEmpty(prop.stringValue)
                                ? AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(prop.stringValue)
                                : null;
        }

        public void Dispose()
        {
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        }
    }
}

#endif