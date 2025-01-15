using UnityEngine;
using PowerTools.Attributes;

[Toggles("A, B, C")]
[Searchable] 
public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [ToggleGroup("A")]
    [TabView(Alignment.Left)]
    [TabGroup("A")]
    [BoxGroup] 
    [DrawRadius("#FFFF00")]
    [Title("This is SPARTAAAAA!", "Assemble brodars")]
    public float blastRadius = 10f;

    [DrawLine]
    [PositionHandle]
    public Vector2 vector2;

    [GetFromSelf, Required("Required Bro")]
    public MeshRenderer meshRenderer;

    [SceneName]
    public string scene;

    [Button("Print Scene")]
    public void PrintScene()
    {
        Debug.Log(scene);
    }
}