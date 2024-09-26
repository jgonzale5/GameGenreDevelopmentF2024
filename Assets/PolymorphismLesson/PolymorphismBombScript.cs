using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphismBombScript : MonoBehaviour
{
    //The radius of the explosion
    public float bombRadius;
    //The damage that this bomb deals to its targets
    public int damage;

    // Update is called once per frame
    void Update()
    {
        //If the player presses the space bar
        if (Input.GetButtonDown("Jump"))
        {
            //Get all colliders within a bombRadius radius of this object
            Collider[] targets = Physics.OverlapSphere(this.transform.position, bombRadius);

            //For each collider detected within that radius...
            foreach (var t in targets)
            {
                //If the game object where the collider detected is also has a BaseEntityScript...
                if (t.transform.TryGetComponent<BaseEntityScript>(out BaseEntityScript entity))
                {
                    //Call the damage function on the entity with the damage dealt by this bomb
                    entity.Damage(damage);
                }

                //If the collider shares game object with an EnemyBaseEntiytScript, its name is displayed.
                if (t.transform.TryGetComponent<EnemyBaseEntityScript>(out EnemyBaseEntityScript enemy))
                {
                    Debug.Log(enemy.gameObject.name + " is an enemy hit by this bomb.");
                }
            }
        }
    }
}
