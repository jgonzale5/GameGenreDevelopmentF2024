using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsLessonHealthbarScript : MonoBehaviour
{
    //
    public Slider healthBarSlider;


    //This function is called when this object is enabled, at the same time as Start
    private void OnEnable()
    {
        //subscribe the SetHealthbarToZero to the OnTimmyKilled event
        EventsLessonScript.OnTimmyKilled += SetHealthbarToZero;

        //Subscribes UpdateHealthbar to OnTimmyHurt
        EventsLessonScript.OnTimmyHurt += UpdateHealthbar;
    }

    //This function is called when this object is disabled or destroyed
    private void OnDisable()
    {
        //Unsubcribes the SetHealthbarToZero function from OnTimmyKilled
        EventsLessonScript.OnTimmyKilled -= SetHealthbarToZero;

        //Unubscribes UpdateHealthbar to OnTimmyHurt
        EventsLessonScript.OnTimmyHurt -= UpdateHealthbar;
    }

    //When called, it sets the slider to 0
    public void SetHealthbarToZero(GameObject killedObject)
    {
        healthBarSlider.normalizedValue = 0;
    }

    //
    public void UpdateHealthbar(GameObject hurtObject, int newHealth)
    {

    }
}
