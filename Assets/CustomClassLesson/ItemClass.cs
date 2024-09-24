using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemClass
{
    public string displayName;
    [TextArea(3, 5)]
    public string description;
    public Transform prefab;
}
