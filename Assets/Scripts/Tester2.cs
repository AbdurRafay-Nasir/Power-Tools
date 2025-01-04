using UnityEngine;
using PowerEditor.Attributes;

// [UsePowerScene]
[Toggles("Walk, Sprint, Swim")]
public class Tester2 : MonoBehaviour
{

    [ToggleGroup("Walk")]
    [BoxGroup]
    [Title("MAAAAAAAAAAAA", "MAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAA", Alignment.Center), DrawRadius]
    public float val = 5f;

    [FoldoutGroup("My Foldout"), PositionHandle, DrawLine]
    public Vector3 target;

    [ShowIf("target.z <= target.y")]
    [ShowIf("val == 10f")]
    [EndGroup(4)]
    public float showIfExample = 5f;
}
