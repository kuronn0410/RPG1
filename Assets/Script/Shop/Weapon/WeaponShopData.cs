using UnityEngine;

[System.Serializable] 
public class WeaponShopData:IShop
{
    
    [SerializeField] Sprite weaponSprite;
    [SerializeField] string weaponName;
    [SerializeField] int price;
    [SerializeField] WeaponType weaponType;

    //IShopインターフェースの実装
    public Sprite Sprite => weaponSprite;
    public string Name => weaponName;
    public int Price => price;
    //WeaponShopDataクラスのプロパティ
    public WeaponType WeaponType => weaponType;

    public void Purchase()
    {
        PossessionWeapon.Instance.AddWeapon(weaponType);
    }

    public bool IsOwned()
    {
        return PossessionWeapon.Instance
         .HasWeapon(weaponType);
    }
}