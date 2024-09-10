using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting2D : MonoBehaviour
{
    //How long the raycasts coming out of this gun should be
    public float gunRange;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Not the right way to do it, but illustrating it
            //The position of the mouse on the screen (using screen space, where 0,0 is left-bottom and top right is screenWidth,screenHeight
            Vector2 mouseScreenPo = Input.mousePosition;

            //Gets the position of the mouse on the screen on the world. Since this is in screen space, its z axis will be equal to the camera.
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPo);
            //Adjust the z value of the mouse world position so its aligned with the gun
            mouseWorldPosition.z = this.transform.position.z;

            //The vector between the player's hand and the mouse
            Vector3 HandToMouse = mouseWorldPosition - this.transform.position;

            //Shoots in the direction between the object and the mouse
            Shoot(HandToMouse.normalized);

            //The better way to do it, but I wanted to illustrate normalized vectors
            //Shoot(this.transform.right);
        }
    }

    //This function casts a ray from this object in the direction specified and destroys any objects with the tag "Target" that it hits.
    public void Shoot(Vector3 direction)
    {
        //Cast the ray in 2D in the direction specified, with the range value specified in the gunRange variable
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, gunRange);
        //Shows the raycast as a gizmo for debugging purposes
        Debug.DrawLine(this.transform.position, this.transform.position + direction * gunRange, Color.red, 1f);

        //If the raycast hit an object with the tag "Target"
        if (hit.collider != null && hit.transform.CompareTag("Target"))
        {
            //Destroy that object
            Destroy(hit.transform.gameObject);
        }
    }
}
