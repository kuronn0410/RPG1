using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    //public WeaponType weaponType;
    public void SetWeaponType(WeaponType newWeaponType)
    {
        //weaponType = newWeaponType;
        PlayerLevelData.currentWeaponType = newWeaponType;
    }
}
