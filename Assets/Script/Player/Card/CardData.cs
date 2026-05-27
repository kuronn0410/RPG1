using UnityEngine;

[System.Serializable]
public class CardData 
{
    public CardType cardType;
    public CardEffectType cardEffectType;
    public Sprite cardSprite;
    public string cardName;
    public GameObject cardPrefab;
    public int cost;
}
