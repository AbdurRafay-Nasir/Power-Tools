using UnityEngine;
using PowerEditor.Attributes;

[UsePowerInspector]
public class Tester2 : MonoBehaviour
{
    [Required("Bro this is required")]
    public GameObject go;

    [SerializeField, Required("This is required")] Sprite sprite; 
}
