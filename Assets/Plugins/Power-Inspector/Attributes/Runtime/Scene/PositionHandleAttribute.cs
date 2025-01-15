using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PositionHandleAttribute : PropertyAttribute, ISceneAttribute
    {
        public bool HideWhenInspectorIsClosed { get; set; }

        private readonly bool useLocalOrientation;

        public PositionHandleAttribute(bool useLocalOrientation = false)
        {
            this.useLocalOrientation = useLocalOrientation;
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
            if (property.propertyType == SerializedPropertyType.Vector3)
            {
                SetVector3Value(target, fieldInfo);
            }

            else if (property.propertyType == SerializedPropertyType.Vector2)
            {
                SetVector2Value(target, fieldInfo);
            }

            else if (property.propertyType == SerializedPropertyType.ObjectReference ||
                     property.objectReferenceValue != null)
            {
                Transform targetTransform = property.objectReferenceValue as Transform;
                SetTransformValue(targetTransform);
            }
        }

        private void SetVector3Value(Object target, FieldInfo field)
        {
            Vector3 oldVal = (Vector3)field.GetValue(target);
            Vector3 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

            if (newVal != oldVal)
            {
                Undo.RecordObject(target, "undo Vector3 value");
                field.SetValue(target, newVal);
            }
        }

        private void SetVector2Value(Object target, FieldInfo field)
        {
            Vector2 oldVal = (Vector2)field.GetValue(target);
            Vector2 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

            if (newVal != oldVal)
            {
                Undo.RecordObject(target, "undo Vector2 value");
                field.SetValue(target, newVal);
            }
        }

        private void SetTransformValue(Transform transform)
        {
            Vector3 oldVal = transform.position;            
            Vector3 newVal;

            if (!useLocalOrientation)
                newVal = Handles.PositionHandle(oldVal, Quaternion.identity);
            else
                newVal = Handles.PositionHandle(oldVal, transform.rotation);

            if (newVal != oldVal)
            {
                Undo.RecordObject(transform, "undo Transform value");
                transform.position = newVal;
            }
        }

#endif
    }
}
