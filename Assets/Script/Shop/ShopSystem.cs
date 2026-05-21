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

    public void PurchaseProcess(int price, WeaponType weaponType)
    {
        if(price<=PlayerLevelData.money)
        {
            if (possessionWeapon.HasWeapon(weaponType))
            {
                possessionWeapon.AddWeapon(weaponType);
                moneySystem.DecreaseMoney(price);
            }

        }
    }




}
