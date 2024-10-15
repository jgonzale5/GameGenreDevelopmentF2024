using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsLessonScript : MonoBehaviour
{
    //this will define a type of delegate
    //a delegate event is basically a variable that stores functions
    //              v the type of the functions that this can store
    //                      v just an identifier to use it as a type
    //                              v the parameters that a function stored in this event must meet
    public delegate void KillEvent(GameObject killedEntity);
    //The OnTimmyKilled event, calls the functions that will execute when Timmy is killed
    //              v This prevents this event from being changed (although it can still be subscribed and unsubscribed to) from outside this script.
    public static event KillEvent OnTimmyKilled;

    //An action is practically identitical to a delegate event, but without having to define a delegate type before using it
    public static Action<GameObject, int> OnTimmyHurt;

    private void Start()
    {
        //At the start, subscribe the "SayNameOfKilled" and the "HideMesh" functions to OnTimmyKilled
        OnTimmyKilled += SayNameOfKilled;
        OnTimmyKilled += HideMesh;
    }

    /// <summary>
    /// Kills timmy. Invokes the OnTimmyKilled event.
    /// </summary>
    public void KillTimmy()
    {
        //Make sure OnTimmyKilled is not empty before invoking it, otherwise we'll get an error.
        if (OnTimmyKilled != null)
        {
            //We invoke the OnTimmyKilled event with this object as its target.
            OnTimmyKilled.Invoke(this.gameObject);
        }
    }

    /// <summary>
    /// This function displays the name of the game object that's being killed.
    /// </summary>
    /// <param name="obj">The object we're "killing".</param>
    public void SayNameOfKilled(GameObject obj)
    {
        //Display the name of the object in the console.
        Debug.Log(obj.name);
    }

    /// <summary>
    /// this function look for a meshrenderer component in the object sent to it
    /// If it finds it, it hides it
    /// </summary>
    /// <param name="inObject">The object where the mesh renderer is located.</param>
    public void HideMesh(GameObject inObject)
    {
        //If the object has a mesh renderer
        if (inObject.TryGetComponent<MeshRenderer>(out MeshRenderer rend))
        {
            //Disable the mesh renderer
            rend.enabled = false;
        }
    }

}
