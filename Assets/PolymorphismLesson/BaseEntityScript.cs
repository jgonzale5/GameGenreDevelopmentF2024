using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BaseEntityScript : MonoBehaviour
{
    //The health of this entity when it spawns
    public int maxHealth;

    //The current health of this entity
    //The protected keyword allows an otherwise private variable to be visible by child classes
    protected int currentHealth;

    //At the start of the game, we set the current health to the maximum
    private void Start()
    {
        currentHealth = maxHealth;
    }

    //When this function is called, damage is dealt to this entity
    public void Damage(int dmg)
    {
        //Subtract the damage from the current health
        currentHealth -= dmg;

        //Debug.Log(this.gameObject.name + " HP = " + currentHealth);

        //If the health of this entity reaches 0 it dies.
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    //This function kills this entity
    //We add the virtual keyword to make this function overridable
    public virtual void Kill()
    {
        Destroy(this.gameObject);
    }
}
