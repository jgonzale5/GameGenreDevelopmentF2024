using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventsLessonHPNumberScript : MonoBehaviour
{
    //
    public TextMeshProUGUI HPText;


    //This function is called when this object is enabled, at the same time as Start
    private void OnEnable()
    {
        //subscribe the SetHPToZero to the OnTimmyKilled event
        EventsLessonScript.OnTimmyKilled += SetHPToZero;
    }

    //This function is called when this object is disabled or destroyed
    private void OnDisable()
    {
        //Unsubcribes the SetHPToZero function from OnTimmyKilled
        EventsLessonScript.OnTimmyKilled -= SetHPToZero;
    }

    //When called, sets the value of the HP text display to 0
    public void SetHPToZero(GameObject killedObject)
    {
        HPText.text = "0";
    }
}
