public abstract class SinglePropertyAttribute : InspectorAttribute
{
    public abstract UnityEngine.UIElements.VisualElement CreatePropertyGUI(UnityEditor.SerializedProperty property);
}
