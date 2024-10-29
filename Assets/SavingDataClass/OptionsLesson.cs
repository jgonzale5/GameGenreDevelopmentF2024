using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsLesson : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;

    private void Start()
    {
        PlayerSettings.Load();
        UpdateSliders();
    }

    public void SetMasterVolume(float value)
    {
        PlayerSettings.SetMasterVolume(value);
    }
    public void SetMusicVolume(float value)
    {
        PlayerSettings.SetMusicVolume(value);
    }
    public void SetSFXVolume(float value)
    {
        PlayerSettings.SetSFXVolume(value);
    }

    public void UpdateSliders()
    {
        masterVolumeSlider.normalizedValue = PlayerSettings.masterVolume;
        musicVolumeSlider.normalizedValue = PlayerSettings.musicVolume;
        SFXVolumeSlider.normalizedValue = PlayerSettings.SFXVolume;
    }

    public void SaveOptions()
    {
        PlayerSettings.Save();
    }
}
