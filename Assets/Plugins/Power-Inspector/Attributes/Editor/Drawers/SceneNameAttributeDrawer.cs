#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNameAttributeDrawer : PropertyDrawer, System.IDisposable
    {
        private DropdownField dropDown;
        private SerializedProperty prop;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
                return new HelpBox("<color=green>[SceneName]</color> is only valid on strings.", HelpBoxMessageType.Error);

            prop = property;
            Undo.undoRedoPerformed += OnUndoRedoPerformed;

            List<string> sceneNames = new();

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                sceneNames.Add(sceneName);
            }

            dropDown = new DropdownField(property.name, sceneNames, property.stringValue);
            dropDown.AddToClassList("unity-base-field__aligned");

            dropDown.RegisterValueChangedCallback((callback) =>
            {
                property.stringValue = dropDown.value;
                property.serializedObject.ApplyModifiedProperties();
            });

            property.stringValue = dropDown.value;
             
            return dropDown;
        }

        private void OnUndoRedoPerformed()
        {
            prop.serializedObject.Update();
            dropDown.value = prop.stringValue;
        }

        public void Dispose()
        {
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        }
    }
}

#endif