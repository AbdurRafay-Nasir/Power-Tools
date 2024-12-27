using PowerEditor.Attributes;
using UnityEngine;

// [UsePowerInspector]
public class Test3 : MonoBehaviour
{
    // [Required("AAA")]
    public GameObject go;

    [Range(0f, 10f)]
    public float f5;

    [SerializeField] GameObject[] gameObjects;
}
