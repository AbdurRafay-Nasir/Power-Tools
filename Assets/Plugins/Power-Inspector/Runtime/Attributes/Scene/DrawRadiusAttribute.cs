using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DrawRadiusAttribute : PowerAttribute, ISceneAttribute
    {
        private readonly Color lineColor;

        public DrawRadiusAttribute()
        {
            lineColor = Color.green;
        }

        public DrawRadiusAttribute(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out Color color))
            {
                lineColor = color;
            }
            else
            {
                lineColor = Color.green;
            }
        }

        public void Draw(UnityEngine.Object target, SerializedProperty property, FieldInfo field)
        {
            Transform transform = (target as MonoBehaviour).transform;

            if (property.propertyType == SerializedPropertyType.Float)
            {
                float oldVal = (float)field.GetValue(target);

                Color oldColor = Handles.color;
                Handles.color = lineColor;
                float newVal = Handles.RadiusHandle(transform.rotation, transform.position, oldVal);
                Handles.color = oldColor;

                if (newVal != oldVal)
                {
                    Undo.RecordObject(target, "undo float value");
                    field.SetValue(target, newVal);
                }
            }
        }
    }
}