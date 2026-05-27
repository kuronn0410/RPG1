using UnityEngine;
using System.Collections.Generic;

public class PossessionCard : MonoBehaviour
{
   
   public static HashSet<CardType> possessionCards = new HashSet<CardType>();

    void Awake()
    {
        possessionCards.Add(CardType.HealPotion);
    }

    public bool HasCard(CardType cardType)
    {
        return possessionCards.Contains(cardType);
    }


    public void AddCard(CardType cardType)
    {
        possessionCards.Add(cardType);
    }
    

}
