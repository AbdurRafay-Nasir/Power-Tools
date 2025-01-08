#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerTools.Attributes.Editor
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

            // By default unity adds this class on Child Fields of PropertyField
            // Since this field is added as a child of PropertyField through code
            // we need to add it manaully. 
            // NOTE - The root that we are returning will become child of PropertyField
            // which is Added in PowerInspectorEditor.cs. For more info refer to:
            // https://docs.unity3d.com/6000.0/Documentation/Manual/UIE-uxml-element-PropertyField.html#:~:text=Align%20a%20PropertyField,consistency%20and%20compatibility.
            objectField.AddToClassList("unity-base-field__aligned");

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