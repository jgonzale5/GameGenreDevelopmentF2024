using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class StationaryEnemyEntityScript : EnemyBaseEntityScript
{

    // Update is called once per frame
    void Update()
    {
        //Execute the current state in the state machine
        ExecuteCurrentState();
    }

    //This function, when called, will kill this enemy
    public override void Kill()
    {
        //Destroys the enemy and shows a message
        Debug.Log(this.gameObject.name + " has been killed.");
        Destroy(this.gameObject);

    }

    //This functiom, when called, will make the enemy attack. What that means isn't currently defined.
    protected override void Attack()
    {
        Debug.Log("Punch");
    }
    
    //this function executes the current state in the state machine of this enemy
    //There currently aren't any states defined.
    protected override void ExecuteCurrentState()
    {
        Debug.Log("This enemy is doing nothing.");
    }
}
