using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Require this component to share a game object with a character controller component
[RequireComponent(typeof(CharacterController))]
public class PlayerMovementScript : MonoBehaviour
{
    //the character controller on this game object that we use to move the player
    private CharacterController characterController;
    //The speed at which this player moves
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Get the character controller on this game object
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Convert the user input into two variables to get how much it should move in each axis
        float xMov = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMov = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //Have the caracter controller component move the player in the inteded direction
        characterController.Move(new Vector3 (xMov, 0, yMov));
    }
}
