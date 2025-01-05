using UnityEngine;
using PowerEditor.Attributes;

[Toggles("Walk, Sprint, Swim")]
public class Tester2 : MonoBehaviour
{
    [ToggleGroup("Walk")]
    [TabView, TabGroup("A"), BoxGroup]
    [Title("This is a title", "Sample description: lorem ipsum dolor sit amit it lit iss psi", Alignment.Center)]
    public float val = 5f;

    [EndGroup(2), TabGroup("B")]
    [FoldoutGroup("My Foldout")]
    public Vector3 target;

    [EndGroup(2), TabGroup("C")]
    public float showIfExample = 5f;
}
