#if UNITY_EDITOR

using UnityEditor;

namespace PowerTools.Attributes.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PowerScriptableObject), true)]
    public class PowerScriptableObjectEditor : PowerEditor { }
}

#endif