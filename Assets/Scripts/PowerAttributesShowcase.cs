using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [Margin(Vertical = 20f)]
    public float f1;
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