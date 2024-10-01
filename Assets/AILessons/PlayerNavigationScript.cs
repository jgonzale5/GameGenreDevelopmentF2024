using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//We add the AI library of Unity
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerNavigationScript : MonoBehaviour
{
    //The agent that controls the movement of this character
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //We find the navmeshagent and assign it
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Get the point the player clicked and mvoe the player there
            GetPlayerDestination();
        }
    }

    //This function calculates where the player is clicking and sets the agent destination there
    private void GetPlayerDestination()
    {
        //Will get us a ray coming from the camera in the direction that the player clicked
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //If the click landed on a physical object
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity))
        {
            //We set the point of contact with the object to be the player's destination
            agent.destination = hit.point;
        }
    }
}
