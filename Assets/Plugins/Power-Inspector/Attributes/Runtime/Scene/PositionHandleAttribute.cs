using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PowerTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PositionHandleAttribute : PropertyAttribute, ISceneAttribute
    {
        public bool useLocalOrientation;

        public bool hideWhenInspectorIsClosed { get; set; }

        public PositionHandleAttribute()
        {

        }

        public PositionHandleAttribute(bool useLocalOrientation)
        {
            this.useLocalOrientation = useLocalOrientation;
        }

        public void Draw(UnityEngine.Object target, SerializedProperty property, FieldInfo field)
        {
            if (property.propertyType == SerializedPropertyType.Vector3)
            {
                SetVector3Value(target, field);
            }

            else if (property.propertyType == SerializedPropertyType.Vector2)
            {
                SetVector2Value(target, field);
            }

            else if (property.propertyType == SerializedPropertyType.ObjectReference ||
                     property.objectReferenceValue != null)
            {
                Transform targetTransform = property.objectReferenceValue as Transform;
                SetTransformValue(targetTransform);
            }
        }

        private void SetVector3Value(UnityEngine.Object target, FieldInfo field)
        {
            Vector3 oldVal = (Vector3)field.GetValue(target);
            Vector3 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

            if (newVal != oldVal)
            {
                Undo.RecordObject(target, "undo Vector3 value");
                field.SetValue(target, newVal);
            }
        }

        private void SetVector2Value(UnityEngine.Object target, FieldInfo field)
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
    }
}
