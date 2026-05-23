using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponDatabase : ScriptableObject
{
    public List<WeaponParameter> weapons = new List<WeaponParameter>();

    public WeaponParameter GetWeaponData(
        WeaponType weaponType)
    {
        return weapons.Find(
            w => w.weaponType == weaponType);
    }
}
