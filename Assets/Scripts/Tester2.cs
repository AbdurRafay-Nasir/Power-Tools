using UnityEngine;
using PowerEditor.Attributes;

[Toggles("Walk, Sprint")]
public class Tester2 : MonoBehaviour
{
    [ToggleGroup("Walk")]
    [TabView, TabGroup("A")]
    public float val = 5f;

    [EndGroup, TabGroup("B")]
    public Vector3 target;

    [EndGroup, TabGroup("C")]
    public float showIfExample = 5f;

    [EndGroup(3), ToggleGroup("Sprint")]
    [BoxGroup]
    public float f1;

    [FoldoutGroup("AWDAW")]
    public float f2;
    public float f3;
}
