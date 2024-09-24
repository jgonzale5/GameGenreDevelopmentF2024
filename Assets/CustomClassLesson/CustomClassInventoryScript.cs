using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomClassInventoryScript : MonoBehaviour
{


    //
    public ItemClass[] items;


    //The prefab that contains the items on the inventory
    public AdvancedItemPrefabScript itemPrefab;

    //the parent where the item buttons are going to be spawned
    public Transform itemNameParent;

    //The display for the name of the selected item
    public TextMeshProUGUI selectedItemNameDisplay;
    //The display for the description of the selected item
    public TextMeshProUGUI selectedItemDescriptionDisplay;

    //The transform currently spawned for 3d inspection
    private Transform currentlyDisplayingItemTransform;
    //The parent where the spawned item will be instantiated under
    public Transform selectedItemTrasformParent;

    private void Start()
    {
        PopulateInventoryList();
    }

    private void PopulateInventoryList()
    {
        //
        foreach (ItemClass i in items)
        {
            //Spawn an item name prefab at the specified parent object
            AdvancedItemPrefabScript temp = Instantiate(itemPrefab, itemNameParent);

            //Sets the properties of the ui item element spawned to match the item 
            temp.SetItem(i);

            //Set the manager of the ui element spawned to be this script
            temp.SetManager(this);

            //Set the name of the object to match the item
            temp.name = i.displayName;
        }
    }

    //
    public void DisplayItem(ItemClass i)
    {
        //Display the properties of the item for now as a debug message.
        Debug.Log(string.Format("{0} is selected.\nDescription: {1}", i.displayName, i.description));

        //Change the text on the name display to match the selected item
        selectedItemNameDisplay.text = i.displayName;

        //Change the text on the description display to match the item description
        selectedItemDescriptionDisplay.text = i.description;


        //If we have a 3d object already spawned that corresponds to the item selected, we destroy it before spawning the new one
        if (currentlyDisplayingItemTransform != null)
        {
            Destroy(currentlyDisplayingItemTransform.gameObject);
        }

        //We instantiate the prefab corresponding to the selected item
        //currentlyDisplayingItemTransform = Instantiate(i.prefab, selectedItemTrasformParent);
        //We specify the position and the rotation so it matches the parent and isn't offset
        currentlyDisplayingItemTransform = Instantiate(i.prefab, selectedItemTrasformParent.position, selectedItemTrasformParent.rotation, selectedItemTrasformParent);
    }
}
