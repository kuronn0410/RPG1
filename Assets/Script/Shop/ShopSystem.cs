using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private PossessionWeapon possessionWeapon;
    [SerializeField] private MoneySystem moneySystem;
    //private WeaponaType weaponaType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        possessionWeapon = FindObjectOfType<PossessionWeapon>();
        moneySystem = FindObjectOfType<MoneySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PurchaseProcess(int price, WeaponType weaponType)
    {
        Debug.Log("’l“n‚µ");
        if(price<=PlayerLevelData.money)
        {
            Debug.Log("‚¨‹àˆ—");
            if (!possessionWeapon.HasWeapon(weaponType))
            {
                possessionWeapon.AddWeapon(weaponType);
                moneySystem.DecreaseMoney(price);

                Debug.Log("w“ü¬Œ÷");
                return true;
            }
            Debug.Log("‚·‚Å‚ÉŠŽ");
            return false;
        }
        Debug.Log("‚¨‹à•s‘«");
        return false;
    }




}
