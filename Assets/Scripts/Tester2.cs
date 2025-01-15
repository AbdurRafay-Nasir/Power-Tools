using UnityEngine;
using PowerTools.Attributes;

[Toggles("Walk, Sprint")]
public class Tester2 : PowerMonoBehaviour
{
    [ToggleGroup("Walk")]
    [TabView(Alignment.Left)]
    [TabGroup("A")]
    public float val = 5f;
    [EndGroup]

    [TabGroup("B")]
    public Vector3 target;
    [EndGroup]

    [TabGroup("C")]
    public float showIfExample = 5f;
    [EndGroup]
    [EndGroup]
    [EndGroup]

    [ToggleGroup("Sprint")]
    [BoxGroup] 
    public float f1;

    [FoldoutGroup("AWDAW")]
    public float f2;

    public float f3;
}
