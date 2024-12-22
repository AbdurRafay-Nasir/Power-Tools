using UnityEngine;
using PowerEditor.Attributes;

[UsePowerInspector]
public class Tester2 : MonoBehaviour
{
    [Required]
    public GameObject go;

    [SerializeField, Required] Sprite sprite; 
}
