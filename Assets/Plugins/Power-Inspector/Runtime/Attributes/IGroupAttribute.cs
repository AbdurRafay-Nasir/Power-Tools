namespace PowerEditor.Attributes
{
    public interface IGroupAttribute
    {
        UnityEngine.UIElements.VisualElement CreateGroupGUI(in UnityEngine.UIElements.VisualElement parent);
    }
}