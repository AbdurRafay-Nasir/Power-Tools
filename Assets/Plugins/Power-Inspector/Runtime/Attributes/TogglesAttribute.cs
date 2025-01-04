using System;
using UnityEngine;

namespace PowerEditor.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TogglesAttribute : PowerAttribute
    {
        public string[] toggleNames;

        public TogglesAttribute(string toggles)
        {
            toggleNames = toggles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < toggleNames.Length; i++)
                toggleNames[i] = toggleNames[i].Trim();
        }
    }
}