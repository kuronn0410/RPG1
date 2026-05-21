using UnityEngine;
using UnityEngine.UI;

public class ShopProductButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text nameTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private WeaponType weaponType;
    private int price;  
    private string weaponName;
    private ShopSystem shopSystem;

    public void SetUp(ShopSystem shopSystem,WeaponType weaponType, int price, string weaponName)
    {
        this.shopSystem = shopSystem;
        this.weaponType = weaponType;
        this.price = price;
        this.weaponName = weaponName;
        nameTxt.text = weaponName;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnPurchaseButtonClicked);
    }

    public void OnPurchaseButtonClicked()
    {
        shopSystem.PurchaseProcess(price, weaponType);
    }
}