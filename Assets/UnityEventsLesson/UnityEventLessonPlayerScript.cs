using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventLessonPlayerScript : MonoBehaviour
{
    //The animator controlling the animations
    public Animator animator;

    //The game object with the left hand
    public GameObject leftHand;
    //The game object with the right hand
    public GameObject rightHand;

    //The radius of the sphere casted from the fist when it tries to deal damage
    public float attackRange;

    //The particle effect that spawns when an enemy is hit
    public Transform hitEffect;

    //The event invoked when this player is hit by a punch
    public UnityEvent OnHit;

    //The custom unityevent we made so we can modularly set up what happens when a hit is attempted
    [System.Serializable]
    public class PunchEvent : UnityEvent<GameObject> { };
    //This indicates what happens when a hit is attempted
    public PunchEvent OnAttemptHit;
    //A custom unityEvent we made so we can spawn particles are specific locations
    [System.Serializable]
    public class ParticleEvent : UnityEvent<Vector3> { };
    //The event called when a hit is succesful.
    public ParticleEvent OnSuccessfulHit;

    /// <summary>
    /// Plays the punch animation
    /// </summary>
    public void Punch()
    {
        //Set the Punch trigger to true, to start the punch animation
        animator.SetTrigger("Punch");
    }

    /// <summary>
    /// This function is called when the left hand is able to do damage
    /// </summary>
    public void LeftHandHit()
    {
        Debug.Log("Left hand attempted to hit.");
        //Invokes the OnAttemptHit event, and sends it the game object of the left hand
        OnAttemptHit.Invoke(leftHand);
    }

    /// <summary>
    /// This function is called when the left hand is able to do damage
    /// </summary>
    public void RightHandHit()
    {
        Debug.Log("Right hand attempted to hit.");
        //Invokes the OnAttemptHit event, and sends it the game object of the right hand
        OnAttemptHit.Invoke(rightHand);
    }

    /// <summary>
    /// Determines if the GameObject received is connecting with another player.
    /// </summary>
    /// <param name="fist">The game object of the fist that's trying to deal damage.</param>
    public void DealDamage(GameObject fist)
    {
        Debug.Log(fist.name + " is trying to deal damage.");

        //This will temporarily cache all the colliders touched during this punch
        var collisionsFound = Physics.OverlapSphere(fist.transform.position, attackRange);

        //For each of the colliders inside the overlapSphere...
        foreach (var c in collisionsFound)
        {
            //If the collider doesn't belong to this same player
            //AND
            //The collider is in a game object with the unityeventlessonplayerscript component
            //Then we can assume that's another player, and we can hit em
            if (c.gameObject != this.gameObject && c.TryGetComponent<UnityEventLessonPlayerScript>(out UnityEventLessonPlayerScript otherPlayer))
            {
                //Tell the other player they've been hit
                otherPlayer.Hit();
                //Invoke the OnsuccessfulHit event to spawn a particle
                OnSuccessfulHit.Invoke(fist.transform.position);
            }
        }
    }

    /// <summary>
    /// Plays the hit animation
    /// </summary>
    public void Hit()
    {
        Debug.Log(gameObject.name + " has been hit!");

        //Invoke the OnHit event
        OnHit.Invoke();
    }

    /// <summary>
    /// Spawns a hit effect at the specified location
    /// </summary>
    /// <param name="at"></param>
    public void SpawnHitEffect(Vector3 at)
    {
        //Spawn the hit particle at the specified location
        Instantiate(hitEffect, at, Quaternion.identity);
    }
}
