using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseEntityScript : BaseEntityScript
{
    //The speed of this enemy. It's an internal variable that keeps track of the enemy speed
    [SerializeField]
    protected float _speed;
    //This is a property definition. 
    //It defines what happens when a variable is read (get)
    //And defines what happens when a variable is changed (set)
    public float speed
    {
        get
        {
            return _speed;
        }

        //set
        //{
        //    _speed = value;
        //}
    }

    //The attack function that all enemies have, but each execute differently
    protected abstract void Attack();

    //Execute the current state of this enemy
    protected abstract void ExecuteCurrentState();

    //This abstract function needs to be overridden 
    //However, it also forces to override the kill function in the base entity script
    public override abstract void Kill();
}
