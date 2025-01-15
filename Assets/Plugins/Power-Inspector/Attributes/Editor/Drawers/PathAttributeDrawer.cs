#if UNITY_EDITOR

using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(PathAttribute))]
    public class PathAttributeDrawer : PropertyDrawer, System.IDisposable
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

            Undo.undoRedoPerformed += OnUndoRedoPerformed;
            
            prop = property;
            objectField = new ObjectField(property.displayName) 
            {
                allowSceneObjects = false
            };

            // By default unity adds this class on Child Fields of PropertyField
            // Since this field is added as a child of PropertyField through code
            // we need to add it manaully. For more info refer to:
            // https://docs.unity3d.com/6000.0/Documentation/Manual/UIE-uxml-element-PropertyField.html#:~:text=Align%20a%20PropertyField,consistency%20and%20compatibility.
            objectField.AddToClassList("unity-base-field__aligned");

            // Set the start value for ObjectField
            objectField.value = string.IsNullOrEmpty(prop.stringValue) ? null
                                : AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(prop.stringValue);

            objectField.RegisterValueChangedCallback((evt) =>
            {
                if (evt.newValue != null)
                {
                    string path = AssetDatabase.GetAssetPath(evt.newValue);

                    property.stringValue = path;
                }
                else
                {
                    property.stringValue = "";
                }

                property.serializedObject.ApplyModifiedProperties();
            });

            return objectField;
        }

        private void OnUndoRedoPerformed()
        {
            prop.serializedObject.Update();

            objectField.value = string.IsNullOrEmpty(prop.stringValue) ? null
                                : AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(prop.stringValue);
        }

        public void Dispose()
        {
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        }
    }
}

#endif