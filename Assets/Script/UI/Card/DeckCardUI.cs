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

    public void RemoveDeckCardUI(CardType cardType)
    {
        for (int i = buttons.Count - 1; i >= 0; i--)
        {
            buttons[i].DestroyCardButton();
        }

        buttons.Clear();

        totalHorizontalInterval = 0;
        totalVerticalInterval = 0;
        totalCardCount = 0;

        foreach (var hascardType in CardDeckManager.setcards)
        {
            AddCardData(hascardType);
        }
    }

    public void AddDeckCardData(CardType cardType)
    {
        AddCardData(cardType);
    }

    

}
