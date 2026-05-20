using UnityEngine;

public class WeaponSwitchUI : MonoBehaviour
{
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private CurrentWeapon currentWeapon;
    [SerializeField] private WeaponType weaponType;

    void Start()
    {
        if (weaponHolder == null)
        {
            Debug.LogError("WeaponHolder is not assigned in the inspector.");
        }
        if (currentWeapon == null)
        {
            Debug.LogError("CurrentWeapon is not assigned in the inspector.");
        }
    }

    public void SwitchWeapon()
    {
        if (weaponHolder == null || currentWeapon == null)
        {
            Debug.LogError("WeaponHolder or CurrentWeapon is not assigned.");
            return;
        }
        weaponHolder.ChangeWeapon(weaponType);
        currentWeapon.SetWeaponType(weaponType);
    }
}
