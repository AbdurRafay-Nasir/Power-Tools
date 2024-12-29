using UnityEngine;
using PowerEditor.Attributes;

[UsePowerScene]
public class Tester2 : MonoBehaviour
{

    [DrawRadius]
    public float val = 5f;

    [PositionHandle, DrawLine]
    public Vector3 target;

    [ShowIf("target.z <= target.y")]
    [ShowIf("val == 10f")]
    public float showIfExample = 5f;

    //[Helpbox("Type your info here", UnityEngine.UIElements.HelpBoxMessageType.Info), Required]
    //public GameObject go;

    //[SerializeField, Required, Helpbox("Type your info here", UnityEngine.UIElements.HelpBoxMessageType.Error)] Sprite sprite;

    //[GetFromSelf]
    //public string kk;

    //[GetFromParent(true)]
    //public Rigidbody rb;

    //[FilePath]
    //public string file;

    //// [ContextMenu("TEST")]
    //[Button("TEST")]
    //public void TEST()
    //{
    //    Debug.Log(file);
    //}


    //[ShowIf("val > 1")]
    //public string scenes;

    //[DrawLine, PositionHandle]
    //public Vector3 target = new(15f, 15f, 15f);

    //[DrawLine("#FFFFFF"), PositionHandle(true)]
    //public Transform t;

    //[PrefabOnly]
    //public GameObject prefab;

    //[Button("PrintScene")]
    //public void PRINT()
    //{
    //    Debug.Log(scenes);
    //}

    // [GetFromChild(true)]
    // public Tester t;

    //[Required]
    //public Tester t1;

    //[GetFromSelf]
    //public Transform tra;

}
