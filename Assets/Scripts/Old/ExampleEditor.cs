using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Example))]
public class ExampleEditor : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        root.Add(new PropertyField(serializedObject.FindProperty("e1")));
        root.Add(new PropertyField(serializedObject.FindProperty("e2")));

        return root;
    }
}
