using System;
using UnityEditor;
using UnityEngine;
//using PowerEditor.Misc;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PositionHandleAttribute : PowerAttribute, ISceneAttribute
    {
        public void Draw(UnityEngine.Object target, SerializedProperty property)
        {
            //Vector3 handlePosition = property.GetField();

            //if (property.propertyType == SerializedPropertyType.Vector3)
            //Handles.PositionHandle()
        }

        public bool IsValid(SerializedProperty property)
        {
            return (property.propertyType == SerializedPropertyType.Vector3 ||
                    property.propertyType == SerializedPropertyType.Vector2);
        }
    }
}
