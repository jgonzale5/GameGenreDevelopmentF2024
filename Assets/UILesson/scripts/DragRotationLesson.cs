using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotationLesson : MonoBehaviour
{
    //The last registered mouse position
    private Vector2 lastMousePos;

    //How many degrees per pixel will the cube rotate
    public float degreesPerUnit;

    //The cube that rotates
    public Transform targetCube;

    //Rotate the cube based on mouse position
    public void RotateCube()
    {
        //We get the current mouse position
        Vector2 currentMousePos = Input.mousePosition;

        //We get the vector representing the mouse movement
        Vector2 slideVector = currentMousePos - lastMousePos;

        //Rotate the cube around the up axis by the horizontal amount of the sliding multiplied by the degrees specified
        targetCube.Rotate(targetCube.up, degreesPerUnit * -slideVector.x);

        //Update the last mouse position to match the current one
        lastMousePos = currentMousePos;
    }

    //Will set the last mouse position to the current mouse position
    public void SetLastMousePosition()
    {
        //Ditto
        lastMousePos = Input.mousePosition;
    }
}
