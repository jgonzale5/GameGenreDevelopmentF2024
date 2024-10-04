using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //The distance the enemy will aim to be when chasing
    public float minPlayerDistance;
    //The maximum distance the enemy will be 
    public float maxPlayerDistance;

    //The states this enemy can be in
    public enum EnemyStates { Idle, Patrol, Chase, Attack, Dead};
    //The current state of the enemy
    private EnemyStates _currentState;
    //The property determining what the current state of the enemy is
    /// <summary>
    /// This is an example of a summary. They're great.
    /// </summary>
    public EnemyStates currentState
    {
        get
        {
            //Get the current state
            return _currentState;
        }
        set
        {
            //If the new value is the same as the old one, we do nothing
            if (value == _currentState)
                return; 

            //If the new value is idle, we reset the idle counter
            if (value == EnemyStates.Idle)
            {
                idleWaitTimeCounter = 0;
            }
            //Whenever the state is set to patrol
            else if (value == EnemyStates.Patrol)
            {
                //We calculate a new patrol destination by taking the current position and adding a random value in range
                patrolDestination = this.transform.position + new Vector3(Random.Range(-patrolRange, patrolRange), 0, Random.Range(-patrolRange, patrolRange));
            }
            //If the new value is to attack, we reset the combat counter
            else if (value == EnemyStates.Attack)
            {
                combatCooldownCounter = 0;
            }

            //We set the current state
            _currentState = value;
        }
    }

    [Header("Detection")]
    //Maximum distance that the player may be seen by the enemy
    public float visionRange;
    //The layers that block this enemy's eyesight
    public LayerMask visionBlockers;
    //The transform representing the eyes of the enemy
    public Transform eyes;
    //The tag objects have when they are part of the player
    public string playerTag;

    [Header("Idling Time")]
    //How long an enemy will wait between patrols
    public float idleWaitTime;
    //The counter keeping track of the time since the last patrol
    private float idleWaitTimeCounter = 0;

    [Header("Patrol")]
    //How far the patrol target position may be
    public float patrolRange;
    //
    private Vector3 patrolDestination;
    //
    public float minPatrolDestinationDistance;

    [Header("Combat")]
    //How long between each attack
    public float combatCooldown;
    //The variable that keeps track of how many seconds have passed since the last attack
    private float combatCooldownCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //We get the naxmeshagent component on this object
        agent  = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Based on the current state, execute a differnt state
        switch (currentState)
        {
            case EnemyStates.Idle:
                Idle();
                break;
            case EnemyStates.Patrol:
                Patrol();
                break;
            case EnemyStates.Chase:
                Chase();
                break;
            case EnemyStates.Attack:
                Attack();
                break;
            case EnemyStates.Dead:
                Dead();
                break;
            default:
                Debug.Log("State not recognized");
                break;
        }
    }

    /// <summary>
    /// This function tells us whether the target object is visible to this enemy.
    /// </summary>
    /// <returns>Return true if a raycast casted from this enemy's eyes hit a collider with the tag "player".</returns>
    bool IsTargetVisible()
    {

        Debug.DrawRay(eyes.position, (target.position - eyes.position).normalized * visionRange, Color.red, 0.01f);

        //If the player is behind the enemy, we dont check if we can see them
        //The dot product of two normal vectors will be
        // 1 when they're parallel
        // 0 when they're perpendicular
        //-1 when they're opposite
        if (Vector3.Dot((target.position - eyes.position).normalized, eyes.forward) < 0)
        {
            return false;
        }

        //We cast a ray from this enemy's eyes, in the direction of the target (player), making sure it goes through glass and other enemies, and that it goes go longer than maxPlayerDistance.
        //We store the hit in the hit variable so we can get information from it.
        if (Physics.Raycast(
            eyes.position, 
            (target.position - eyes.position).normalized, 
            out RaycastHit hit, 
            visionRange, 
            visionBlockers
            ))
        {
            //If the object hit by the ray has the player tag, we are looking at the player.
            if (hit.transform.CompareTag(playerTag))
            {
                return true;
            }
        }

        return false;
    }

    //State machines

    private void Idle()
    {
        if (IsTargetVisible())
        {
            currentState = EnemyStates.Chase;
            return;
        }

        //Add the time passed this frame
        idleWaitTimeCounter += Time.deltaTime;

        //If enough time has passed to shift to the patrol state, we do
        if (idleWaitTimeCounter >= idleWaitTime)
        {
            currentState = EnemyStates.Patrol;
            return;
        }
    }

    private void Patrol()
    {
        //If the target is visible using the appropiate function
        if (IsTargetVisible())
        {
            //We set the state to chase the target
            currentState = EnemyStates.Chase;
            return;
        }

        //Otherwise,
        //We set the destination of the nav mesh agent to be a random point within maxPatrolDistance of them.
        agent.SetDestination(patrolDestination);

        //If the distance between this enemy and its patrol destination target is less than what is required to have considered this enemy to have "reached" its goal...
        if (Vector3.Distance(this.transform.position, patrolDestination) <= minPatrolDestinationDistance)
        {
            //We put the enemy back into an idle state
            currentState = EnemyStates.Idle;
            return;
        }
    }

    private void Chase()
    {
        //If there is a target
        if (target != null)
        {
            //If the enemy is too close to the player, stop them
            if (Vector3.Distance(target.position, this.transform.position) <= minPlayerDistance)
            {
                agent.isStopped = true;
                currentState = EnemyStates.Attack;
                return;
            }

            //Move towards it
            agent.destination = target.position;
        }
    }

    private void Attack()
    {
        //If the enemy is too far from the player, have them move towards the player
        if (Vector3.Distance(target.position, this.transform.position) > maxPlayerDistance)
        {
            agent.isStopped = false;
            currentState = EnemyStates.Chase;
            return;
        }

        combatCooldownCounter += Time.deltaTime;

        if (combatCooldownCounter >= combatCooldown)
        {
            Debug.Log("ATTACKED " + target.name);
            combatCooldownCounter = 0;
        }
    }

    private void Dead()
    {

    }
}
