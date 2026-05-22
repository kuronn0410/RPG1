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
    public bool isPurchased;

    public void SetUp(ShopSystem shopSystem,WeaponType weaponType, int price, string weaponName)
    {

        Debug.Log("セットアップ");
        this.shopSystem = shopSystem;
        this.weaponType = weaponType;
        this.price = price;
        this.weaponName = weaponName;
        isPurchased = false;
        nameTxt.text = weaponName;
        Debug.Log(button);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            Debug.Log("BUTTON CLICK");
            OnPurchaseButtonClicked();
        });
        //button.onClick.AddListener(OnPurchaseButtonClicked);
    }

    public void OnPurchaseButtonClicked()
    {
        if (isPurchased)
        {
            Debug.Log("すでに購入済み");
            return;
        }
        Debug.Log("購入ボタンがクリックされました");
        bool purchaseSuccessful = shopSystem.PurchaseProcess(price, weaponType);

        if (purchaseSuccessful)
        {
            isPurchased = true;
            button.interactable = false; // 購入後はボタンを無効化するなどの処理
            button.image.color = Color.gray; // ボタンの色を変えるなどの処理
        }
    }
}