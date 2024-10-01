using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add this library so we can do operations with the nav mesh agent
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigationScript : MonoBehaviour
{
    //The transform that this enemy will be chasing
    public Transform target;
    //The agent that controls this object's navigation
    public NavMeshAgent agent;

    //
    public float minPlayerDistance;
    //
    public float maxPlayerDistance;

    // Start is called before the first frame update
    void Start()
    {
        //We get the naxmeshagent component on this object
        agent  = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //If there is a target
        if (target != null)
        {
            //If the enemy is too close to the player, stop them
            if (Vector3.Distance(target.position, this.transform.position) <= minPlayerDistance)
            {
                agent.isStopped = true;
            }
            //If the enemy is too far from the player, have them move towards the player
            else if (Vector3.Distance(target.position, this.transform.position) > maxPlayerDistance)
            {
                agent.isStopped = false;
            }

            //Move towards it
            agent.destination = target.position;
        }
    }
}
