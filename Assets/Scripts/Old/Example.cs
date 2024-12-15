using UnityEngine;

public class Example : MonoBehaviour
{
    [Header("AAA")] [Tooltip("TIP")] [ReadOnly] public float e1;
    [Range(0f, 100f)] [Space] [Tooltip("TIP")]  public float e2 = 10f;
}
