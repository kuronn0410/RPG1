using UnityEngine;
using RPG.Player;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] WeaponDatabase weaponDatabase;
    [SerializeField] GameObject player;
    //[SerializeField] CurrentWeapon currentWeapon;
    private PlayerAttack playerAttack;
    private WeaponDamage weaponDamage;
    private WeaponParameter weaponParameter;
    private GameObject currentPrefab;

    void Start()
    {
        playerAttack = player.GetComponent<PlayerAttack>();
        //currentWeapon = GetComponent<CurrentWeapon>();
        //weaponDamage = player.GetComponentInChildren<WeaponDamage>();
        ChangeWeapon(PlayerLevelData.currentWeaponType);
        
        if (playerAttack == null)
        {
            Debug.LogError("PlayerAttack component not found!");
            return;
        }
    }

    public bool ChangeWeapon(WeaponType newWeaponType)
    {
        weaponParameter = weaponDatabase.weapons.Find(w => w.weaponType == newWeaponType);
        if (weaponParameter == null)
        {
            Debug.LogError("Weapon not found!");
            return false;
        }
        WeaponGeneration();
        PlayerLevelData.currentWeaponType = newWeaponType;
        return true;
    }

    public bool CheckCurrentWeapon(WeaponType weaponType)
    {
        return PlayerLevelData.currentWeaponType == weaponType;
    }

    void WeaponGeneration()
    {
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }

        currentPrefab = Instantiate(
            weaponParameter.weaponPrefab,
            parentObject.transform
        );

        currentPrefab.transform.localPosition = Vector3.zero;
        currentPrefab.transform.localRotation = Quaternion.identity;
        weaponDamage = currentPrefab.GetComponentInChildren<WeaponDamage>();
        if(weaponDamage == null)
        {
            Debug.LogError("WeaponDamage missing on prefab!");
            return;
        }

        if (playerAttack == null)
        {
            Debug.LogError("playerAttack is NULL (Startèáî‘ÉoÉO)");
            return;
        }
        playerAttack.SetWeaponDamage(weaponDamage);

    }
}
