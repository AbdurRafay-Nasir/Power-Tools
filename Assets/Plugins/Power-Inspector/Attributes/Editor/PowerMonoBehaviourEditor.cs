#if UNITY_EDITOR

using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PowerTools.Attributes.Editor
{
    [CustomEditor(typeof(PowerMonoBehaviour), true)]
    public class PowerMonoBehaviourEditor : PowerEditor
    {
        private Dictionary<SerializedProperty, SceneAttributeData> sceneAttributesDict = new();

        protected override void OnEnable()
        {
            base.OnEnable();

            foreach (var property in serializedProperties)
            {
                List<Attribute> allAttributes = property.GetAttributes();
                List<ISceneAttribute> sceneAttributes = new();

                foreach (var attr in allAttributes)
                {
                    if (attr is ISceneAttribute sceneAttr)
                    {
                        sceneAttributes.Add(sceneAttr);
                    }
                }

                if (sceneAttributes.Count > 0)
                {
                    SceneAttributeData data = new SceneAttributeData();
                    data.fieldInfo = property.GetField();
                    data.sceneAttributes = sceneAttributes;

                    sceneAttributesDict.Add(property, data);
                }
            }

            foreach (var entry in sceneAttributesDict)
            {
                foreach (var sceneAttr in entry.Value.sceneAttributes)
                {
                    sceneAttr.Setup(target, entry.Key, entry.Value.fieldInfo);
                }
            }
        }

        private void OnSceneGUI()
        {
            if (sceneAttributesDict.Count == 0)
                return;

            foreach (var entry in sceneAttributesDict)
            {
                SerializedProperty property = entry.Key;
                List<ISceneAttribute> sceneAttributes = entry.Value.sceneAttributes;

                foreach (var sceneAttr in sceneAttributes)
                {
                    if (sceneAttr.HideWhenInspectorIsClosed)
                    {
                        if (!UnityEditorInternal.InternalEditorUtility.GetIsInspectorExpanded(target))
                            continue;
                    }

                    sceneAttr.Draw();
                }
            }
        }

        private void PrintDictionary()
        {
            foreach (var entry in sceneAttributesDict)
            {
                List<ISceneAttribute> attributes = sceneAttributesDict[entry.Key].sceneAttributes;

                foreach (var attr in attributes)
                {
                    Debug.Log(entry.Key.name + ": has " + attr.GetType().Name);
                }
            }
        }
    }

    internal struct SceneAttributeData
    {
        public List<ISceneAttribute> sceneAttributes;
        public FieldInfo fieldInfo;
    }
}

#endif