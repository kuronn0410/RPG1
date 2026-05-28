using UnityEngine;
using System.Collections.Generic;

public class PossessionCard : MonoBehaviour
{
    public static PossessionCard Instance;


    [SerializeField] private PossessionCardUI possessionCardUI;

    void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        possessionCards.Add(CardType.HealPotion);

    }


    public static HashSet<CardType> possessionCards = new HashSet<CardType>();

    public bool HasCard(CardType cardType)
    {
        return possessionCards.Contains(cardType);
    }


    public void AddCard(CardType cardType)
    {
        possessionCards.Add(cardType);
        possessionCardUI.AddPossessionCardData(cardType);
    }
    

}
