using UnityEngine;
using System.Collections.Generic;

// カードデッキの管理をするクラス
//現在のデッキの枚数・カードの種類を管理するクラス
public class CardDeckManager : MonoBehaviour
{
    public static CardDeckManager Instance;

    [SerializeField] private PossessionCardUI possessionCardUI;

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
    int count = 0;
    public  static List<CardType> setcards = new List<CardType>();

    public void AddCardToDeck(CardType card)
    {
        if (count < DeckCardNumber)
        {
            count++;
            setcards.Add(card);
            deckCardUI.AddDeckCardData(card);
            possessionCardUI.ResetAllButtons();

            Debug.Log("カードをデッキに追加しました。現在のカード数: " + count);

        }
        else
        {
           return;
        }
    }

    public void RemoveCardFromDeck(CardType card)
    {
        if (count > 0)
        {
            count--;
            setcards.Remove(card);
            possessionCardUI.ResetAllButtons();
            Debug.Log("カードをデッキから削除しました。現在のカード数: " + count);
        }
        else
        {
            return;
        }
    }

    public bool IsInDeck(CardType cardType)
    {
        return setcards.Contains(cardType);
    }
}