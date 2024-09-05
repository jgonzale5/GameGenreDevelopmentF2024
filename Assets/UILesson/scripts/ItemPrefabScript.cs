using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPrefabScript : MonoBehaviour
{
    //A reference to the component that displays the text
    public TextMeshProUGUI textDisplay;

    //Keeps track of this item name
    private string itemName;
    
    //Changes the name of the list item 
    public void SetName(string to)
    {
        //Change the private name of this item
        itemName = to;

        //Change the public name of this item
        textDisplay.text = itemName;
    }
}
