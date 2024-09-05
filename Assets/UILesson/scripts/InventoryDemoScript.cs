using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDemoScript : MonoBehaviour
{
    //The item names that are being spawned
    public string[] itemNames = new string[0];

    //The prefab that contains the items on the inventory
    public ItemPrefabScript itemPrefab;

    //
    public Transform itemNameParent;

    private void Start()
    {
        PopulateInventoryList();
    }

    private void PopulateInventoryList()
    {
        //Starting at 0, ending at length of itemNames - 1
        for (int i = 0; i < itemNames.Length; i++)
        {
            //Spawn an item name prefab at the specified parent object
            ItemPrefabScript temp = Instantiate(itemPrefab, itemNameParent);

            //Call the SetName function
            temp.SetName(itemNames[i]);

            //Name it the same as the i-th element of itemNames
            temp.name = itemNames[i];
        }
    }
}
