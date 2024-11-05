using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetection : MonoBehaviour
{
    //How many degrees does the turret move in a second
    public float rotationSpeed = 10.0f;
    //The object that is the muzzle of this turret
    public Transform muzzle;
    //The radius of the spherecast this turret does to detect objects
    public float sphereCastRadius;
    //The mesh renderer of the turret, used to change its color
    public MeshRenderer meshRenderer;
    //The tag of the objects that represent characters
    public string characterTag;

    // Update is called once per frame
    void Update()
    {
        //Rotates the turret
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime, Space.World);

        //If the turret sees an object
        if (CheckIfSeesTarget(out RaycastHit hit))
        {
            //If the object has the tag for characters, turn the turret red
            if (hit.transform.CompareTag(characterTag))
            {
                meshRenderer.material.color = Color.red;
            }
            //Otherwise, it's not a character. Turn the turret blue
            else
            {
                meshRenderer.material.color = Color.blue;
            }
        }
        //If it doesn't see any objects, turn the turret cyan
        else
        {
            meshRenderer.material.color = Color.cyan;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool CheckIfSeesTarget(out RaycastHit hitInfo)
    {
        //Use a "thick raycast" of sphereCastRadius units in thickness to see if the turret sees someone
        if (Physics.SphereCast(transform.position, sphereCastRadius, muzzle.forward, out hitInfo))
        {
            //Debug.Log(hit.transform.name);

            return true;
        }

        //Debug.Log("Empty");
        return false;
    }
}
