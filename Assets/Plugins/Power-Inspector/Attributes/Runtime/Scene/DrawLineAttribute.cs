using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DrawLineAttribute : PropertyAttribute, ISceneAttribute
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

        public void Draw(UnityEngine.Object target, SerializedProperty property, FieldInfo field)
        {
            Vector3 lineEnd;

            if (property.propertyType == SerializedPropertyType.Vector3)
            {
                lineEnd = property.vector3Value;
            }
            else if (property.propertyType == SerializedPropertyType.Vector2)
            {
                lineEnd = property.vector2Value;
            }
            else if (property.propertyType == SerializedPropertyType.ObjectReference && 
                     property.objectReferenceValue != null && 
                     property.objectReferenceValue.GetType() == typeof(Transform))
            {
                Transform targetTransform = property.objectReferenceValue as Transform;
                lineEnd = targetTransform.position;
            }
            else
            {
                return;
            }

            Transform transform = (target as MonoBehaviour).transform;

            Color prevColor = Handles.color;
            Handles.color = lineColor;

            Handles.DrawLine(transform.position, lineEnd, lineThickness);
            Handles.color = prevColor;
        }
    }
}