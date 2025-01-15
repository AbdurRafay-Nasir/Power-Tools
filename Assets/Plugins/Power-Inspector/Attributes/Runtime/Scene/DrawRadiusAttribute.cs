using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DrawRadiusAttribute : PropertyAttribute, ISceneAttribute
    {
        private readonly Color lineColor;

        public bool HideWhenInspectorIsClosed { get; set; }

        private Object target;
        private SerializedProperty property;
        private FieldInfo fieldInfo;

        #region Constructors

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

        #endregion

        public void Setup(Object target, SerializedProperty property, FieldInfo field)
        {
            this.target = target;
            this.property = property;
            fieldInfo = field;
        }

        public void Draw()
        {
            Transform transform = (target as MonoBehaviour).transform;

            if (property.propertyType == SerializedPropertyType.Float)
            {
                float oldVal = (float)fieldInfo.GetValue(target);

                Color oldColor = Handles.color;
                Handles.color = lineColor;
                float newVal = Handles.RadiusHandle(transform.rotation, transform.position, oldVal);
                Handles.color = oldColor;

                if (newVal != oldVal)
                {
                    Undo.RecordObject(target, "undo float value");
                    fieldInfo.SetValue(target, newVal);
                }
            }
        }
    }
}