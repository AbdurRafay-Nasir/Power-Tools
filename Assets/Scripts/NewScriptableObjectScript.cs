using PowerTools.Attributes;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
[DisplayScriptField]
public class NewScriptableObjectScript : ScriptableObject
{
    [BoxGroup]
    [Title("AAAAAAAAAAAAAAAA")]
    public float a;
    public float b;
    [FoldoutGroup("FF")]
    public float c;
    public float d;
    public float e;
}
