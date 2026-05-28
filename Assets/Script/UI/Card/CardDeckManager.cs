using UnityEngine;
using System.Collections.Generic;

// カードデッキの管理をするクラス
//現在のデッキのカードの種類を管理するクラス
public class CardDeckManager : MonoBehaviour
{
    public static CardDeckManager Instance;

    //[SerializeField] private PossessionCardUI possessionCardUI;

    void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    [SerializeField] int DeckCardNumber = 5;
    [SerializeField] private DeckCardUI deckCardUI;
    [SerializeField] private UseCardUI useCardUI;
    int count = 0;
    public  static HashSet<CardType> setcards = new HashSet<CardType>();

    public void AddCardToDeck(CardType card)
    {
        if (count < DeckCardNumber)
        {
            count++;
            setcards.Add(card);
            deckCardUI.AddDeckCardData(card);
            useCardUI.AddDeckCardData(card);
            //possessionCardUI.ResetAllButtons();

            Debug.Log("カードをデッキに追加しました。現在のカード数: " + count);

        }
        else
        {
            return;
        }
    }

    //CardButtonStateManagerを呼び出して
    public void RemoveCardFromDeck(CardType card)
    {
        if (count > 0)
        {
            count--;
            setcards.Remove(card);
            deckCardUI.RemoveDeckCardUI(card);
            CardButtonStateManager.Instance.ResetCardByRemovedeck(card);

            Debug.Log("カードをデッキから削除しました。現在のカード数: " + count);
        }
        else
        {
            return;
        }
    }
    /*
    public bool IsInDeck(CardType cardType)
    {
        return setcards.Contains(cardType);
    }
    */
}