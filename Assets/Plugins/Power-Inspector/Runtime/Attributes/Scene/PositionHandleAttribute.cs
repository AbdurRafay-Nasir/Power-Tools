using System;
using UnityEditor;
using UnityEngine;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PositionHandleAttribute : PowerAttribute, ISceneAttribute
    {
        public void Draw(UnityEngine.Object target, SerializedProperty property)
        {
            //Vector3 handlePosition = (Vector3)field.GetValue(target);

            //if (property.propertyType == SerializedPropertyType.Vector3)
            //    Handles.PositionHandle()
        }
    }
}
