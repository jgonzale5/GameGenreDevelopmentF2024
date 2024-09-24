using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdvancedItemPrefabScript : MonoBehaviour
{
    //A reference to the component that displays the text
    public TextMeshProUGUI textDisplay;

    //The item that this prefab script represents
    public ItemClass itemRepresented;

    //The script that spawned this item and manages the ivnentory
    private CustomClassInventoryScript inventoryScript;

    //Sets the item that this UI element is referring to
    public void SetItem(ItemClass to)
    {
        //Set the item represented to the one passed to this function
        itemRepresented = to;

        //Set the text on the textmeshprougui to display the name of the item represented
        textDisplay.text = itemRepresented.displayName;
    }

    //Sets the manager that spawned this object
    public void SetManager(CustomClassInventoryScript to)
    {
        inventoryScript = to;
    }

    //
    public void SelectItem()
    {
        //Tells the inventory script what item this ui element represents so it can show it and stuff
        inventoryScript.DisplayItem(itemRepresented);
    }
}
