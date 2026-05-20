using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WeaponShopDatabase", menuName = "WeaponShopDatabase", order = 1)]
public class WeaponShopDatabase : ScriptableObject
{
    public List<WeaponShopData> weaponShopDatas = new List<WeaponShopData>();
}
