using UnityEngine;

//
public class ShopInteract : MonoBehaviour, IWorldUIDisplayable
{
    [SerializeField] private WorldUIManager worldUIManager;
    [SerializeField] private ShopType shopType;
    public string GetInteractionText()
    {
        return "クリック:ショップを開く";
    }

    public void ShowWorldUI()
    {
       switch(shopType)
       {
            case ShopType.Weapon:
                worldUIManager.ShowWeaponShopButton();
                break;
            case ShopType.Card:
                worldUIManager.ShowCardShopButton();
                break;
       }
    }

    public void HideWorldUI()
    {
        switch(shopType) 
        { 
            case ShopType.Weapon:
                worldUIManager.HideWeaponShopButton();
                break;
            case ShopType.Card:
                worldUIManager.HideCardShopButton();
                break;
        }
    }
}
