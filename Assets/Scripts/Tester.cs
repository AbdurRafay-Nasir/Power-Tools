using UnityEngine;
using PowerEditor.Attributes;
using System.Collections.Generic;

// [UsePowerInspector, UsePowerScene]
public class Tester : MonoBehaviour
{
    //[FoldoutGroup] public int i1;
    //[FoldoutGroup, BoxGroup] public int i2;
    //public int i3;
    //[Required("Bruh, Plz assign this thing")] public GameObject obj;
    //[EndGroup(2)] public int i4;

    ////[Space]
    ////[Title("I AM PROPERTY TITLE")]
    //public int i5;

    //[DrawLine("#ffff00"), PositionHandle]
    //public Vector3 target = new Vector3(10, 10, 10);

    //[PositionHandle]
    public Vector2 target2 = new Vector3(10, 10, 10);

    public List<Vector2> vector2s;
}
