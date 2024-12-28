using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PositionHandleAttribute : PowerAttribute, ISceneAttribute
    {
        public void Draw(UnityEngine.Object target, SerializedProperty property, FieldInfo field)
        {
            //Vector3 handlePosition = (Vector3)field.GetValue(target);

            //if (property.propertyType == SerializedPropertyType.Vector3)
            //    Handles.PositionHandle()
        }


        //private void SetVector3Value(FieldInfo field)
        //{
        //    Vector3 oldVal = (Vector3)field.GetValue(target);
        //    Vector3 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

        //    if (newVal != oldVal)
        //    {
        //        Undo.RecordObject(target, "undo Vector3 value");
        //        field.SetValue(target, newVal);
        //    }
        //}

        //private void SetVector2Value(FieldInfo field)
        //{
        //    Vector2 oldVal = (Vector2)field.GetValue(target);
        //    Vector2 newVal = Handles.PositionHandle(oldVal, Quaternion.identity);

        //    if (newVal != oldVal)
        //    {
        //        Undo.RecordObject(target, "undo Vector2 value");
        //        field.SetValue(target, newVal);
        //    }
        //}
    }
}
