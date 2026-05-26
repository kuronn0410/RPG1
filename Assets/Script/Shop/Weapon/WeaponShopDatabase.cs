using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[CreateAssetMenu(fileName = "WeaponShopDatabase", menuName = "WeaponShopDatabase", order = 1)]
public class WeaponShopDatabase : ScriptableObject, IShopDatabase
{
    public List<WeaponShopData> weaponShopDatas = new List<WeaponShopData>();

    public List<IShop> GetAllItems()
    {
        return  weaponShopDatas.Cast<IShop>().ToList();
        //List<WeaponShopData>‚ðList<IShop>‚É•ÏŠ·‚µ‚Ä•Ô‚·

    }
}
