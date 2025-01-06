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
    public float f1;
    public float f2;
    public float f3;
}
