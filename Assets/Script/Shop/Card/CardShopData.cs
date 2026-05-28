using UnityEngine;

[System.Serializable]
public class CardShopData :IShop
{
   [SerializeField] Sprite cardSprite;
   [SerializeField] int price;
   [SerializeField] string name;
   [SerializeField] CardType cardtype;

    public Sprite Sprite => cardSprite;
    public string Name => name;
    public int Price => price;

    public CardType cardType => cardtype;

    public void Purchase()
    {
        PossessionCard.Instance.AddCard(cardtype);
    }

    public bool IsOwned()
    {
        return PossessionCard.Instance.HasCard(cardtype);
    }


}
