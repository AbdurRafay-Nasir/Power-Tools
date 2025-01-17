using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [Title("This is Spartaaaaaa!!!!", "Assemble Brodars. We are gonna win this game")]
    public int i1;
    public int i2;
}

/*
 * [Toggles("A, B, C")]
[Searchable]
[DisplayScriptField]
 * 
 * 
    [ToggleGroup("A")]
    [TabView(Alignment.Left)]
    [TabGroup("A")]
    [BoxGroup] 
    [DrawRadius("#FFFF00")]
    [Title("This is SPARTAAAAA!", "Assemble brodars")]
    public float blastRadius = 10f;

    [DrawLine]
    [PositionHandle]
    [FoldoutGroup("AA")]
    public Vector2 vector2;

    [GetFromSelf, Required("Required Bro")]
    public MeshRenderer meshRenderer;

    [Path, EndGroup]
    public string scene;

    [Button("Print Scene")]
    public void PrintScene()
    {
        Debug.Log(scene);
    }
 */