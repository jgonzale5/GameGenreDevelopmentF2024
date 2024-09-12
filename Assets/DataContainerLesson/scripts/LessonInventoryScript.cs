using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonInventoryScript : MonoBehaviour
{
    //The list of items that we've picked
    private List<string> pickedItems = new List<string>();

    private void Update()
    {
        //If we left click
        if (Input.GetMouseButtonDown(0))
        {
            //Generate a ray indicating the origin and direction of the click in respect to the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.DrawRay(ray.origin, ray.direction * Mathf.Infinity, Color.red, 5f);

            //If the ray hits something, put the details of the hit in the hit variable
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.name);
                //If we found the specified script in the transform of the collider that we hit, we store it in a temporary variable "script"
                //Doesn't work for children
                if (hit.transform.TryGetComponent<PickableItemScript>(out PickableItemScript script))
                //This will work for children
                /*PickableItemScript script;
                if (
                    (script = hit.transform.GetComponentInChildren<PickableItemScript>()) 
                    != null
                    )*/
                {
                    //We call the PickItem function with the component we got
                    PickItem(script);
                }
            }
        }
    }

    public void PickItem(PickableItemScript item)
    {
        //Add the item picked to the inventory
        pickedItems.Add(item.itemName);

        Debug.Log(item.itemName + " was added.");

        //Destroy the item picked
        Destroy(item.gameObject);

        DisplayInventory();
    }

    //Displays the inventory as a debug message
    public void DisplayInventory()
    {
        //An empty string
        string output = "";

        //For each item in the pickedItems list
        foreach (var item in pickedItems)
        {
            //Add it to the output string
            output = output + item + "\n";
        }

        //Display the output string
        Debug.Log(output);
    }
}
