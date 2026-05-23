using UnityEngine;
using System.Collections.Generic;

public class PossessionWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSwitchUI weaponSwitchUI;
    public static HashSet<WeaponType> possessionWeapon = new HashSet<WeaponType>();

    private void Awake()
    {
        // èâä˙ïêäÌ
        possessionWeapon.Add(WeaponType.Sword);
    }


    public bool HasWeapon(WeaponType weaponType)
    {
        return possessionWeapon.Contains(weaponType);
    }

    public void AddWeapon(WeaponType weaponType)
    {
        possessionWeapon.Add(weaponType);
        weaponSwitchUI.GetPossessionWeapon(weaponType);

    }
}
