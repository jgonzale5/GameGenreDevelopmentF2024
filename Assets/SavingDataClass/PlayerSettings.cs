using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public static class PlayerSettings
{
    public static float masterVolume;
    public static float musicVolume;
    public static float SFXVolume;

    public static void SetMasterVolume(float to)
    {
        masterVolume = to;
        Debug.Log("Master Volume: " + masterVolume);
    }

    public static void SetMusicVolume(float to)
    {
        musicVolume = to;
        Debug.Log("Music volume: " + musicVolume);
    }
    public static void SetSFXVolume(float to)
    {
        SFXVolume = to;
        Debug.Log("SFX Volume: " + SFXVolume);
    }

    public static void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
    }

    public static void Load()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
    }
}
