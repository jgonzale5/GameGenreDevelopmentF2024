using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
public class FakeLoading : MonoBehaviour
{
    [Header("Spinning wheel settings")]
    //The amount of seconds each spin takes
    public float secondsPerRevolution;
    //Internal variable to keep track of time passed
    private float secondsPassed;
    //Whether the wheel is currently filling clockwise
    private bool clockWise = true;

    //The image that will be modified
    private Image image;

    [Header("Time Counter Settings")]
    //The text with the time under the wheel
    public TextMeshProUGUI timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //Look for the image component on this object and assign it
        image = this.transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the spinner is currently filling up
        if (clockWise)
        {
            //Add the time passed to the seconds passed
            secondsPassed += Time.deltaTime;

            //If the amount of seconds passed is more than what it takes for the spinner to do a revolution
            if (secondsPassed > secondsPerRevolution)
            {
                //Match both so it doesn't mess up with the time
                secondsPassed = secondsPerRevolution;

                //Change the direction that it will fill (and hence, unfill)
                clockWise = false;
                image.fillClockwise = false;
            }
        }
        //Repeat what's above but in the other direction
        else
        {
            secondsPassed -= Time.deltaTime;

            if (secondsPassed < 0)
            {
                secondsPassed = 0;

                clockWise = true;
                image.fillClockwise = true;
            }
        }

        //Update the fill amount to represent the ratio between seconds passed and seconds per revolution
        image.fillAmount = secondsPassed / secondsPerRevolution;

        //Display the time in minutes and seconds:
        //-If we divide the amount of seconds by 60 and cut the decimals, we get the amount of minutes
        //-If we get the remainder of that division and cut the decimals, we get the amount of seconds in that minute
        //We use ToString("00") to format the text with a minimum of two digits.
        timeDisplay.text = string.Format("{0}:{1}", Mathf.FloorToInt(secondsPassed / 60).ToString("00"), Mathf.FloorToInt(secondsPassed % 60).ToString("00"));
    }
}
