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
        }

        private void OnSceneGUI()
        {
            if (sceneAttributesDict.Count == 0)
                return;

            foreach (var entry in sceneAttributesDict)
            {
                SerializedProperty property = entry.Key;

                List<ISceneAttribute> sceneAttributes = sceneAttributesDict[property].sceneAttributes;
                foreach (var sceneAttr in sceneAttributes)
                {
                    sceneAttr.Draw(target, property, sceneAttributesDict[property].fieldInfo);
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