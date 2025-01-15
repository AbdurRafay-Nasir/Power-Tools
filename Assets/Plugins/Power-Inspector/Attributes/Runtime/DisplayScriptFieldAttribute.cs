using System;

namespace PowerTools.Attributes
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DisplayScriptFieldAttribute : UnityEngine.PropertyAttribute { }
}