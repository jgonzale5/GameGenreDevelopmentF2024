using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //The position of the mouse on the screen (using screen space, where 0,0 is left-bottom and top right is screenWidth,screenHeight
        Vector3 mouseScreenPo = Input.mousePosition;

        //Gets the position of the mouse on the screen on the world. Since this is in screen space, its z axis will be equal to the camera.
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPo);
        //Adjust the z value of the mouse world position so its aligned with the gun
        mouseWorldPosition.z = this.transform.position.z;

        //The vector between the player's hand and the mouse
        Vector3 HandToMouse = mouseWorldPosition  - this.transform.position;

        //Make it so the right of the hand is pointing to the mouse
        this.transform.right = HandToMouse;

        //This part is to correct any misadjustments from the previous step. To align the right vector of the object with the direction, the object may rotate in the x axis
        //when we don't want it to, this will correct it while maintaining the right vector alignment.
        Vector3 localRotation = this.transform.localEulerAngles;
        localRotation.x = 0;

        //Updates the object to feature the fixes.
        this.transform.localEulerAngles = localRotation;
    }
}
