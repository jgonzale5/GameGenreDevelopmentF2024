using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresnoNightcrawlerDemo : MonoBehaviour
{
    public Animator animator;
    public KeyCode walkForward = KeyCode.W;
    public KeyCode die = KeyCode.D;

    public enum characterStates { Idle = 0, Chasing = 1, Dead = 3};

    private void Update()
    {
        if (Input.GetKey(walkForward))
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(die))
        {
            animator.SetInteger("State", (int)characterStates.Dead);
        }
    }
}
