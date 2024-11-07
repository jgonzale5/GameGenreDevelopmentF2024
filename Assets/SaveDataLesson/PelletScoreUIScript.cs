using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using TMPro;

public class PelletScoreUIScript : MonoBehaviour
{
    //The UI element that will display the score
    public TextMeshProUGUI textDisplay;

    //When this object or component is enabled, we add the SetScoreText function to the events triggered by a change in the score
    private void OnEnable()
    {
        PlayerScoreLessonScript.OnScoreChanged += SetScoreText;
    }

    //When this object or component is disabled or destroyed, we remove the SetScoreText function from the score change events to prevent fatal errors.
    private void OnDisable()
    {
        PlayerScoreLessonScript.OnScoreChanged -= SetScoreText;
    }

    //Called to update the score text display
    public void SetScoreText(int to)
    {
        textDisplay.text = to.ToString();
    }
}
