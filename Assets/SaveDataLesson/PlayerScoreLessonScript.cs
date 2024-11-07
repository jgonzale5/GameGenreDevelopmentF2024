using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreLessonScript : MonoBehaviour
{
    //The current player score, internally
    private int _score = 0;
    //the property managing the score
    public int score
    {
        //Return the score normally
        get
        {
            return _score;
        }
        set
        {
            //Whenever the score is changed, we call the appropiate event
            _score = value;
            OnScoreChanged.Invoke(_score);
        }
    }
    //the event of things that happen when the score changes
    public static Action<int> OnScoreChanged;
    //The tag of the pellets, to distinguish them from the floor and the world
    public string pelletTag = "Coin";

    private void Start()
    {
        //Create a path for the savefile
        SaveDataManager.BuildPath("PlayerSaveFile");
        //Load the file in the filepath into the savefile variable
        SaveDataManager.Load();
        //Update the score to match the one in the savefile
        score = SaveDataManager.saveFile.score;
    }

    //On enable, make it so the saveFile is updated every time the score changes
    private void OnEnable()
    {
        OnScoreChanged += SaveDataManager.SetScore;
    }

    //On disabke remove the Setscore function from the event
    private void OnDisable()
    {
        OnScoreChanged -= SaveDataManager.SetScore;
    }

    //When this player touches a pellet, it picks it up
    private void OnTriggerEnter(Collider other)
    {
        //If the object we interacted with is tagged as a pellet
        if (other.CompareTag(pelletTag))
        {
            //The score is increased
            score++;
            //The pellet is destroyed
            Destroy(other.gameObject);
            //After every picked up pellet the save file is updated
            SaveDataManager.Save();
        }
    }
}
