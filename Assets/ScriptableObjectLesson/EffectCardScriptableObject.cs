using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/EffectCard", order = 1)]
public class EffectCardScriptableObject : CardScriptableObject
{
    public void ExecuteEffect()
    {
        Debug.Log("Something happened here.");
    }
}
