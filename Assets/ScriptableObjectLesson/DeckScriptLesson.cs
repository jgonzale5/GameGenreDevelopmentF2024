using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScriptLesson : MonoBehaviour
{
    //The list od CardScriptableObjects representing the deck
    [SerializeField]
    List<CardScriptableObject> cards;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleDeck();
    }

    //Removes a card from the deck and returns it
    public CardScriptableObject DrawCard()
    {
        //If the deck exists and it isn't empty
        if (cards == null || cards.Count == 0)
        {
            return null;
        }

        //We get the card at the front
        CardScriptableObject drawnCard = cards[0];

        //Remove the card from the deck
        cards.RemoveAt(0);

        //Return that card
        return drawnCard;
    }

    //Shuffles the deck list
    public void ShuffleDeck()
    {
        CardScriptableObject temp;

        for (int i = 0; i < cards.Count; i++)
        {
            //We chose a random card on the seck
            int otherCardIndex = Random.Range(0, cards.Count - 1);

            //We swap both variables
            temp = cards[i];
            cards[i] = cards[otherCardIndex];
            cards[otherCardIndex] = temp;
        }
    }
}
