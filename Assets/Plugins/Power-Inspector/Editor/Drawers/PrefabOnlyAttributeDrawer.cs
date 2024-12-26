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
            PrefabOnlyAttribute attr = (attribute as PrefabOnlyAttribute);

            VisualElement root = new VisualElement();

            if (fieldInfo.FieldType != typeof(GameObject))
            {
                root.Add(new HelpBox("<color=green>[PrefabOnly]</color> is applicable on GameObject reference only", HelpBoxMessageType.Error));
                return root;
            }

            HelpBox helpBox = new HelpBox();
            helpBox.messageType = HelpBoxMessageType.Error;
            helpBox.style.display = DisplayStyle.None;
            root.Add(helpBox);

            PropertyField propertyField = new PropertyField(property);
            root.Add(propertyField);

            propertyField.RegisterValueChangeCallback((changeCallback) =>
            {                
                if (property.objectReferenceValue != null)
                {
                    GameObject go = property.objectReferenceValue as GameObject;
                    helpBox.text = go.name + ": is not a prefab";

                    bool isPrefab = PrefabUtility.IsPartOfPrefabAsset(go);
                    if (!isPrefab)
                    {
                        helpBox.style.display = DisplayStyle.Flex;

                        property.objectReferenceValue = null;
                        property.serializedObject.ApplyModifiedProperties();
                    }
                    else
                    {
                        helpBox.style.display = DisplayStyle.None;
                    }
                }
            });

            return root;
        }
    }
}

#endif