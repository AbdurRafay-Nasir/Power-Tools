using UnityEngine;
using PowerEditor.Attributes;

[UsePowerInspector]
public class Tester2 : MonoBehaviour
{
    [Required, Helpbox("Type your info here", UnityEngine.UIElements.HelpBoxMessageType.Error)]
    public GameObject go;

    [SerializeField, Required, Helpbox("Type your info here", UnityEngine.UIElements.HelpBoxMessageType.Error)] Sprite sprite; 
}
