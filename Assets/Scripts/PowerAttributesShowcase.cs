using UnityEngine;
using PowerTools.Attributes;

[Toggles("A, B, C", PaddingLeft = 10f)]
[Searchable] 
public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [ToggleGroup("A")]
    [TabView]
    [TabGroup("A")]
    [BoxGroup] 
    [DrawRadius("#FFFF00")]
    [GUI("What is BlastRadius?")]
    public float blastRadius = 10f;

    [DrawLine]
    [PositionHandle]
    public Vector2 vector2;

    // [DrawLine]
    public Vector3 vector3;

    [FilePath, GUI("File for ref")]
    public string filePath;

    [Button(nameof(PrintFilePath))]
    private void PrintFilePath()
    {
        Debug.Log(filePath);
    }
}