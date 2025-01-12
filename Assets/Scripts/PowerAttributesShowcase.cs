using UnityEngine;
using PowerTools.Attributes;

[Searchable] 
public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [BoxGroup] 
    [DrawRadius("#FFFF00")]
    public float blastRadius = 10f;

    [DrawLine]
    [PositionHandle]
    public Vector2 vector2;

    [DrawLine]
    public Vector3 vector3;
}