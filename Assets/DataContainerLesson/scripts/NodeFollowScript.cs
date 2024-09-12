using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFollowScript : MonoBehaviour
{
    //The list of nodes this object will be following
    public NodeScript[] nodes;
    //The index of the current node this object is moving towards
    int currentNode = 0;
    //The speed of this object
    public float speed;
    //How close does this object must be to a node before stopping
    public float tolerance;

    // Update is called once per frame
    void Update()
    {
        //What's the target position
        Vector3 targetPosition = nodes[currentNode].transform.position;
        //What's the vector between this object and the target position
        Vector3 direction = targetPosition - this.transform.position;
        //What's the normalized direction between this object and its target
        direction = direction.normalized;

        //Move this object in the direction of their target by the speed specified.
        this.transform.position += direction * speed * Time.deltaTime;

        //If the distance between this object and its target is less than the tolerance
        if (Vector3.Distance(targetPosition, this.transform.position) < tolerance)
        {
            //We increase the currentNode by 1 so we can move to the next target
            currentNode = currentNode + 1;

            //% will return the remainder of a division (e.g. 5 % 2 = 1, 6 % 3 = 0)
            currentNode = currentNode % nodes.Length;
        }
    }
}
