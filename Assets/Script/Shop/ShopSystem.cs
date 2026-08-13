using Unity.VisualScripting;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private MoneySystem moneySystem;
    [SerializeField] private TownAudio townAudio;
    //private WeaponaType weaponaType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //moneySystem = Object.FindAnyObjectByType<MoneySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PurchaseProcess(int price, IShop shopData)
    {
        Debug.Log("’l“n‚µ");
        if(price<=PlayerLevelData.money)
        {
            Debug.Log("‚¨‹àˆ—");
            if (!shopData.IsOwned())//w“ü‚µ‚Ä‚¢‚È‚¢‚©orãŒÀ”‚É’B‚µ‚Ä‚¢‚È‚¢‚©
            {
                shopData.Purchase();
                moneySystem.DecreaseMoney(price);

                Debug.Log("w“ü¬Œ÷");
                townAudio.Play(UISeType.Purchase);
                return true;
            }
            Debug.Log("‚·‚Å‚ÉŠŽ");
            return false;
        }
        Debug.Log("‚¨‹à•s‘«");
        townAudio.Play(UISeType.CantPurchase);
        return false;
    }

}
