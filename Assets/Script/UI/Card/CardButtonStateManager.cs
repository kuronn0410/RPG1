using UnityEngine;
using System.Collections.Generic;

public class CardButtonStateManager : MonoBehaviour
{

    public static CardButtonStateManager Instance;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    List<CardProductButton> cardButtons = new List<CardProductButton>();
    //所持カードのUIを生成する際に呼び出す関数
    public void RegisterCardButton(CardProductButton button)
    {
        if (!cardButtons.Contains(button))
        {
            cardButtons.Add(button);
        }
    }

    /*//所持カードのUIを削除する際に呼び出す関数
    public void UnregisterCardButton(CardProductButton button)
    {
        if()

        if (cardButtons.Contains(button))
        {
            cardButtons.Remove(button);
        }
    }*/

    //デッキから外した時にもう一度押せるようにするための関数
    public void ResetCardByRemovedeck(CardType cardType)
    {
        foreach (var button in cardButtons)
        {
            if (button.GetCardType() == cardType)
            {
                //ボタン側でカードの状態をリセットする関数を呼び出す
                button.ResetButton();
            }
        }
    }

    /*
    public void RefreshAllButtons()
    {
        foreach (var button in cardButtons)
        {
            button.RefreshState();
        }
    }*/
}