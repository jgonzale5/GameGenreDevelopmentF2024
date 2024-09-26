using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateEntityScript : BaseEntityScript
{
    //The object that spawns when this object is destroyed
    public Transform drop;

    //Will return the health of this entity
    public int GetHealth()
    {
        return currentHealth;
    }

    //A public void function that overrides the void function of the same name in the parent class
    public override void Kill()
    {
        //We spawn the drop at the position of this object
        Instantiate(drop, this.transform.position, Quaternion.identity);
        Debug.Log("Killed");
        //We destroy this object
        Destroy(this.gameObject);
    }
}
