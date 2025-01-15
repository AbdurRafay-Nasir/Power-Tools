#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.UIElements;

namespace PowerTools.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNameAttributeDrawer : PropertyDrawer
    {
        private DropdownField dropDown;
        private SerializedProperty prop;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.String)
                return new HelpBox("<color=green>[SceneName]</color> is only valid on strings.", HelpBoxMessageType.Error);

            prop = property;

            List<string> sceneNames = new();

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                sceneNames.Add(sceneName);
            }

            string defaultValue = string.IsNullOrEmpty(property.stringValue) ? sceneNames[0]
                                  : property.stringValue;

            dropDown = new DropdownField(property.displayName, sceneNames, defaultValue);
            dropDown.AddToClassList("unity-base-field__aligned");

            dropDown.BindProperty(property);

            property.stringValue = dropDown.value;
            property.serializedObject.ApplyModifiedProperties();

            dropDown.RegisterValueChangedCallback((evt) =>
            {
                property.stringValue = evt.newValue;
                property.serializedObject.ApplyModifiedProperties();
            });
                         
            return dropDown;
        }
    }
}

#endif