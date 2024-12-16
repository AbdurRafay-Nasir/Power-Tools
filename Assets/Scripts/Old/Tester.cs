using UnityEngine;

[UsePowerEditor]
[Title("I AM A TITLE", alignment = UnityEngine.UIElements.Align.Center)]
public class Tester : MonoBehaviour
{
    [FoldoutGroup, ReadOnly] public int i1;
    [FoldoutGroup, BoxGroup] public int i2;
    public int i3;
    [Required("Bruh, Plz assign this thing")] public GameObject obj;
    [EndGroup, EndGroup] public int i4;

    [Space]
    [Title("I AM PROPERTY TITLE")]
    public int i5;
}
