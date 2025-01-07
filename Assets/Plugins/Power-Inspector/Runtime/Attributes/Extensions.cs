#if UNITY_EDITOR

using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;

namespace PowerEditor.Attributes.Editor
{
    public static class Extensions
    {
        #region Visual Elements Helper Functions

        public static void SetPadding(this VisualElement v, float padding)
        {
            v.style.paddingLeft = padding;
            v.style.paddingRight = padding;
            v.style.paddingTop = padding;
            v.style.paddingBottom = padding;
        }
        public static void SetPadding(this VisualElement v, float horizontal, float vertical)
        {
            v.style.paddingLeft = horizontal;
            v.style.paddingRight = horizontal;
            v.style.paddingTop = vertical;
            v.style.paddingBottom = vertical;
        }
        public static void SetPadding(this VisualElement v, float left, float right, float top, float bottom)
        {
            v.style.paddingLeft = left;
            v.style.paddingRight = right;
            v.style.paddingTop = top;
            v.style.paddingBottom = bottom;
        }

        public static void SetMargin(this VisualElement v, float margin)
        {
            v.style.marginLeft = margin;
            v.style.marginRight = margin;
            v.style.marginTop = margin;
            v.style.marginBottom = margin;
        }
        public static void SetMargin(this VisualElement v, float horizontal, float vertical)
        {
            v.style.marginLeft = horizontal;
            v.style.marginRight = horizontal;
            v.style.marginTop = vertical;
            v.style.marginBottom = vertical;
        }
        public static void SetMargin(this VisualElement v, float left, float right, float top, float bottom)
        {
            v.style.marginLeft = left;
            v.style.marginRight = right;
            v.style.marginTop = top;
            v.style.marginBottom = bottom;
        }

        #endregion

        #region Serialized Object / Properties Helper Functions

        const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        /// <summary>
        /// Returns all Serialized Properties of this Serialized Object
        /// </summary>
        /// <remarks>Will not return null, empty List can be returned</remarks>
        public static List<SerializedProperty> GetAllSerializedProperties(this SerializedObject serializedObject)

        {
            List<SerializedProperty> serializedProperties = new();

            SerializedProperty iterator = serializedObject.GetIterator();
            iterator.NextVisible(true);

            bool isNextPropertyVisible = iterator.NextVisible(false);

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

        #endregion
    }
}

#endif