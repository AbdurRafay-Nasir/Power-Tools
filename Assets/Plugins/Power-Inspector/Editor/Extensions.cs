#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace PowerEditor.Attributes.Editor
{
    public static class Extensions
    {
        const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        /// <summary>
        /// Returns all Serialized Properties of this Serialized Object
        /// </summary>
        /// <remarks>Will not return null, empty List can be returned</remarks>
        public static List<SerializedProperty> GetAllSerializedProperties(this SerializedObject serializedObject,
                                                                          bool ignoreScriptReference = true)
        {
            List<SerializedProperty> serializedProperties = new();

            SerializedProperty iterator = serializedObject.GetIterator();

            bool isNextPropertyVisible = iterator.NextVisible(true);

            if (ignoreScriptReference)
            {
                isNextPropertyVisible = iterator.NextVisible(false);
            }

            while (isNextPropertyVisible)
            {
                serializedProperties.Add(iterator.Copy());
                isNextPropertyVisible = iterator.NextVisible(false);
            }

            return serializedProperties;
        }


        /// <returns>All Attributes this Serialized Property has</returns>
        public static List<Attribute> GetAttributes(this SerializedProperty property)
        {
            Type targetType = property.serializedObject.targetObject.GetType();

            FieldInfo field = targetType.GetField(property.name, bindingFlags);

            if (field == null)
                return new List<Attribute>();

            return new List<Attribute>(field.GetCustomAttributes(false) as Attribute[]);
        }

        /// <returns>Attribute of supplied type T</returns>
        public static T GetAttribute<T>(this SerializedProperty property) where T : Attribute
        {
            Type targetType = property.serializedObject.targetObject.GetType();

            FieldInfo field = targetType.GetField(property.name, bindingFlags);

            return field.GetCustomAttribute<T>();
        }

        /// <returns>Field Info of underlying field, sseful for reflection</returns>
        public static FieldInfo GetField(this SerializedProperty property)
        {
            Type targetType = property.serializedObject.targetObject.GetType();
            return targetType.GetField(property.name, bindingFlags);
        }
    }
}

#endif