using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Test3))]
public class Test3Editor : Editor
{
    public VisualTreeAsset treeAsset;

    public override VisualElement CreateInspectorGUI()
    {
        return treeAsset.Instantiate();
    }
}
