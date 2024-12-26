using UnityEngine;
using PowerEditor.Attributes;

[UsePowerInspector]
public class Tester2 : MonoBehaviour
{
    //[Helpbox("Type your info here", UnityEngine.UIElements.HelpBoxMessageType.Info), Required]
    //public GameObject go;

    //[SerializeField, Required, Helpbox("Type your info here", UnityEngine.UIElements.HelpBoxMessageType.Error)] Sprite sprite;

    //[GetFromSelf]
    //public string kk;

    //[GetFromParent(true)]
    //public Rigidbody rb;

    [FilePath]
    public string file;

    [ContextMenu("TEST")]
    public void TEST()
    {
        Debug.Log(file);
    }

    [PrefabOnly]
    public GameObject prefab;

    [GetFromChild(true)]
    public Tester t;

    //[Required]
    //public Tester t1;

    //[GetFromSelf]
    //public Transform tra;

}
