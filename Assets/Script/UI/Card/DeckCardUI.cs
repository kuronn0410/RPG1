using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DeckCardUI : CardUIBase
{
    void Start()
    {
        foreach (var cardType in CardDeckManager.setcards)
        {
            AddCardData(cardType);
        }
    }

    public void AddDeckCardData(CardType cardType)
    {
        AddCardData(cardType);
    }

    

}
