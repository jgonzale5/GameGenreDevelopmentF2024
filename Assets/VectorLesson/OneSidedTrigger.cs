using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidedTrigger : MonoBehaviour
{
    //Whether this object is expecting objects from the right or not
    public bool FromRight = false;

    //When an object enters this collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Gets the vector between the trigger box and the incoming object
        //THIS IS WRONG
        //Vector3 enteringVector = this.transform.position - collision.transform.forward;
        //THIS IS RIGHT
        Vector3 enteringVector = this.transform.position - collision.transform.position;

        //Defines the vector we're expecting
        Vector3 expectedEntryVector = Vector3.zero;

        //If the box is set to expect movement from the left (i.e. pointing right), we set the expected vector to right 
        if (!FromRight)
            expectedEntryVector = this.transform.right;
        //If the box is set to expect movement from the right (i.e. pointing left), we set the expected vector to left
        else
            expectedEntryVector = this.transform.right * -1;

        //We calculate the dot product between the expected entry vector and the direction the object is moving into the box
        //Vectors are normalized so we can ensure the output will be between -1 and 1, inclusive
        float dotProduct = Vector3.Dot(enteringVector.normalized, expectedEntryVector.normalized);

        //If the product indicates that both vectors are within 180 degrees, we display a message.
        if (dotProduct >= 0)
        {
            Debug.Log("Something entered collider.");
        }
    }
}
