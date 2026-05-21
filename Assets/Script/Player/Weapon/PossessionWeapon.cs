using UnityEngine;
using System.Collections.Generic;

public class PossessionWeapon : MonoBehaviour
{
    private HashSet<WeaponType> possessionWeapon = new HashSet<WeaponType>();


    public bool HasWeapon(WeaponType weaponType)
    {
        return possessionWeapon.Contains(weaponType);
    }

    public void AddWeapon(WeaponType weaponType)
    {
        possessionWeapon.Add(weaponType);
    }
}
