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

    [FilePath]
    public string filePath;
    [FolderPath]
    public string folderPath;


    [Button(nameof(PrintFolderPath))]
    private void PrintFolderPath()
    {
        Debug.Log(folderPath);
    }

    [Button(nameof(PrintFilePath))]
    private void PrintFilePath()
    {
        Debug.Log(filePath);
    }
}