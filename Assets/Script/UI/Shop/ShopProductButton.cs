using UnityEngine;
using UnityEngine.UI;

public class ShopProductButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text nameTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private IShop shopData;
    private int price;  
    private string name;
    private ShopSystem shopSystem;
    public bool isPurchased;

    public void SetUp(ShopSystem shopSystem,IShop shopData)
    {

        //Debug.Log("セットアップ");
        this.shopSystem = shopSystem;
        this.shopData = shopData;

        this.price = shopData.Price;
        this.name = shopData.Name;
        
        isPurchased = false;
        nameTxt.text = name;
        //Debug.Log(button);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            //Debug.Log("BUTTON CLICK");
            OnPurchaseButtonClicked();
        });
        //button.onClick.AddListener(OnPurchaseButtonClicked);
        ConfirmUsage();
    }

    private void ConfirmUsage()
    {
        if (shopData.IsOwned())
        {
            isPurchased = true;
            button.interactable = false; // 購入後はボタンを無効化するなどの処理
            button.image.color = Color.gray; // ボタンの色を変えるなどの処理
        }
    }

    public void OnPurchaseButtonClicked()
    {
        if (isPurchased)
        {
            //Debug.Log("すでに購入済み");
            return;
        }
        //Debug.Log("購入ボタンがクリックされました");
        bool purchaseSuccessful = shopSystem.PurchaseProcess(price, shopData);

        if (purchaseSuccessful)
        {
            isPurchased = true;
            button.interactable = false; // 購入後はボタンを無効化するなどの処理
            button.image.color = Color.gray; // ボタンの色を変えるなどの処理
        }
    }
}