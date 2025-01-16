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
        public bool HideWhenInspectorIsClosed { get; set; }

        private readonly Color lineColor;
                
        public DrawRadiusAttribute(string lineColorHex = "#1FDD1F")
        {
            lineColor = ColorUtility.TryParseHtmlString(lineColorHex, out Color color) ?
                        color : Color.green;
        }

#if UNITY_EDITOR

        private Object target;
        private SerializedProperty property;
        private FieldInfo fieldInfo;

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

#endif
    }
}