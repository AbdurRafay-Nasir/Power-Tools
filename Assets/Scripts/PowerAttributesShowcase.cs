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
    [GUI(MarginVertical = 50f)]
    public float blastRadius = 10f;

    [DrawLine]
    [PositionHandle]
    public Vector2 vector2;

    [GetFromSelf]
    public MeshRenderer meshRenderer;
}