using UnityEngine;
using System.Collections.Generic;

// カードデッキの管理をするクラス
//現在のデッキのカードの種類を管理するクラス
public class CardDeckManager : MonoBehaviour
{
    public static CardDeckManager Instance;


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
    //int count = 0;
    //public  static HashSet<CardType> setcards = new HashSet<CardType>();
    public static List<CardType> setcards = new List<CardType>();
    public bool AddCardToDeck(CardType card)
    {
        if (setcards.Count < DeckCardNumber)
        {
            if (setcards.Contains(card))
                return false;

            setcards.Add(card);
            deckCardUI.AddDeckCardData(card);
            useCardUI.AddDeckCardData(card);
            //count++;

            Debug.Log("カードをデッキに追加しました。現在のカード数: " + setcards.Count);
            return true;
        }
        else
        {
            return false;
        }
    }

    //CardButtonStateManagerを呼び出して
    public void RemoveCardFromDeck(CardType card)
    {
        if (setcards.Contains(card))
        {
            
            setcards.Remove(card);
            deckCardUI.RemoveDeckCardUI(card);
            useCardUI.RemoveDeckCardUI(card);
            CardButtonStateManager.Instance.ResetCardByRemovedeck(card);
            Debug.Log("カードをデッキから削除しました。現在のカード数: " + setcards.Count);
        }
        else
        {
            return;
        }
    }
}