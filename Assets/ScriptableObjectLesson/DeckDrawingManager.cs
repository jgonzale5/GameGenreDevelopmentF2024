using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add the Text Mesh Pro library
using TMPro;
//Add the ui library
using UnityEngine.UI;

public class DeckDrawingManager : MonoBehaviour
{
    //The text displaying the name of the currently drawn card
    public TextMeshProUGUI cardNameDisplay;
    //The text displaying the description of the currently drawn card
    public TextMeshProUGUI cardDescriptionDisplay;
    //The image that will display the illustration of the currently drawn card
    public Image cardIllustrationDisplay;
    //A reference to the script managing the deck
    public DeckScriptLesson deck;

    CardScriptableObject newCard;

    //Draws a card from the deck and displays it on the table
    public void DrawCardFromDeck()
    {
        //Draw a card from the deck
        newCard = deck.DrawCard();

        //If the drawn card is valid
        if (newCard == null)
        {
            Debug.Log("Deck is empty!");
            return;
        }

        //We update the values on the card on the deck with that of the card drawn
        cardNameDisplay.text = newCard.cardName;
        cardDescriptionDisplay.text = newCard.description;
        cardIllustrationDisplay.sprite = newCard.illustration;
    }

    public void ExecuteEffect()
    {
        if (newCard == null)
        {
            return;
        }

        ((EffectCardScriptableObject)newCard).ExecuteEffect();
    }
}
