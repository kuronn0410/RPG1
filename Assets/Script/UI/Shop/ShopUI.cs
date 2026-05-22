using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject productButtonPrefab;
    [SerializeField] Transform parentObj;
    [SerializeField] WeaponShopDatabase weaponShopDatabase;
    [SerializeField] ShopSystem shopSystem;
    [SerializeField] int between;
    

    private int totalbetween =0;
    void Start()
    {
        
        foreach(var data in weaponShopDatabase.weaponShopDatas)
        {
            WeaponType weaponType = data.weaponType;
            int price = data.price;
            string weaponName = data.weaponName;
            CreateProductButton(shopSystem,weaponType, price, weaponName);
            totalbetween += between;
        }
    }


    public void CreateProductButton(ShopSystem shopSystem, WeaponType weaponType, int price, string weaponName)
    {
        
         GameObject button = Instantiate(productButtonPrefab, parentObj);
         button.GetComponent<ShopProductButton>().SetUp(shopSystem, weaponType, price, weaponName);
         button.transform.localPosition = new Vector3(0, -totalbetween, 0);
    }
}
