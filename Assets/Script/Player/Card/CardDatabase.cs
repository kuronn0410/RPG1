using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName="CardDatabase", menuName="Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<CardData> cards = new List<CardData>();

    public CardData GetCardData(
        CardType cardType)
    {
        return cards.Find(
            c => c.cardType == cardType);
    }
}
