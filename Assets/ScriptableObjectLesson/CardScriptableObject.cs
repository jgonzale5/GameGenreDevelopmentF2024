using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    //the name of the card
    public string cardName;
    //The illustration on the card
    public Sprite illustration;
    //The description of the card
    public string description;


}
