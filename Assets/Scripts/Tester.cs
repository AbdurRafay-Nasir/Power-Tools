using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tester : MonoBehaviour
{
    public PowerAttributesShowcase showcase;

    public Button button;
    public TextMeshProUGUI field_TMP;
    public TextMeshProUGUI method_TMP;

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        foreach (FieldInfo field in showcase.GetType().GetFields())
        {
            IEnumerable<Attribute> attributes = field.GetCustomAttributes();

            foreach (var attr in attributes)
            {
                field_TMP.text += $"{field.Name}: {attr.GetType().Name}\n";
            }
        }

        foreach (var method in showcase.GetType().GetMethods())
        {
            IEnumerable<Attribute> attributes = method.GetCustomAttributes();

            foreach (var attr in attributes)
            {
                method_TMP.text += $"{method.Name}: {attr.GetType().Name}\n";
            }
        }
    }
}
