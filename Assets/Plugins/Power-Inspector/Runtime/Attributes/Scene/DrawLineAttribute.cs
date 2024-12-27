using System;
using UnityEditor;
using UnityEngine;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DrawLineAttribute : PowerAttribute, ISceneAttribute
    {
        private readonly float lineThickness;
        private readonly Color lineColor;

        public DrawLineAttribute()
        {
            lineThickness = 2f;
            lineColor = Color.green;
        }

        public DrawLineAttribute(float lineThickness = 2f)
        {
            this.lineThickness = lineThickness < 0.5f ? 0.5f : lineThickness;
            lineColor = Color.green;
        }

        public DrawLineAttribute(string lineColor = "#00ff00")
        {
            lineThickness = 2f;
            if (ColorUtility.TryParseHtmlString(lineColor, out Color color))
            {
                this.lineColor = color;
            }
        }

        public DrawLineAttribute(float lineThickness = 2f, string lineColor = "#00ff00")
        {
            this.lineThickness = lineThickness < 0.5f ? 0.5f : lineThickness;

            if (ColorUtility.TryParseHtmlString(lineColor, out Color color))
            {
                this.lineColor = color;
            }
        }

        public void Draw(UnityEngine.Object target, SerializedProperty property)
        {
            Transform transform = (target as MonoBehaviour).transform;

            Color prevColor = Handles.color;
            Handles.color = lineColor;

            Vector3 value;

            if (property.propertyType == SerializedPropertyType.Vector3)
                value = property.vector3Value;
            else if (property.propertyType == SerializedPropertyType.Vector2)
                value = property.vector2Value;
            else
            {
                Transform targetTransform = property.objectReferenceValue as Transform;
                value = targetTransform.position;
            }

            Handles.DrawLine(transform.position, value, lineThickness);
            Handles.color = prevColor;
        }

        public bool IsValid(SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.Vector3 ||
                property.propertyType == SerializedPropertyType.Vector2 ||
                property.objectReferenceValue.GetType() == typeof(Transform))
            {
                return true;
            }

            return false;
        }
    }
}