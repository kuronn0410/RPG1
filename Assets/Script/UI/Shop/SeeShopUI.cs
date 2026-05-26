using UnityEngine;

public class SeeShopUI : MonoBehaviour, IInteractable
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

}
