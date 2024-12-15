using UnityEngine;

[UsePowerEditor]
[Title]
public class Tester : MonoBehaviour
{
    [FoldoutGroup, ReadOnly] public int i1;
    [FoldoutGroup, BoxGroup] public int i2;
    public int i3;
    [Required("Bruh, Plz assign this thing")] public GameObject obj;
    [EndGroup, EndGroup] public int i4;
}
