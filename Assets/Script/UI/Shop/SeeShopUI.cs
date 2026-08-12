using UnityEngine;

//ボタンを押すとショップが開くたぶんいらない

public class SeeShopUI : MonoBehaviour
{
    [SerializeField] private ShopType shopType;

    public void Interact()
    {
        Debug.Log("Shop Open");
        switch (shopType)
        {
            case ShopType.Weapon:
                UIManager.Instance.ToggleWeaponShopPanel();
                break;
            case ShopType.Card:
                UIManager.Instance.ToggleCardShopPanel();
                break;
        }
    }

    //public string GetInteractionText()
    //{
    //    return "クリック:ショップを開く";
    //}
}
