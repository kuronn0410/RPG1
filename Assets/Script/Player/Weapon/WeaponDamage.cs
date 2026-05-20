using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] WeaponDatabase weaponDatabase;
    [SerializeField] WeaponType weaponType;
    private Collider collider;
    //private PlayerAttack playerAttack;
    private PlayerStatus playerStatus;
    private WeaponParameter weaponParameter;
    private int weaponDamage;
    
    
    void Start()
    {
        switch (weaponType)
        {
            case WeaponType.Sword:
                weaponParameter = weaponDatabase.weapons[0];
                break;
            case WeaponType.Sickle:
                weaponParameter = weaponDatabase.weapons[1];
                break;
            default:
                Debug.LogError("Invalid weapon type!");
                break;
            
        }

        collider = GetComponent<Collider>();
        //playerAttack = GetComponentInParent<PlayerAttack>();
        if(collider!=null)
        {
            collider.enabled = false;
        }
        
        playerStatus = GetComponentInParent<PlayerStatus>();
        weaponDamage = weaponParameter.damage;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            int damage = playerStatus.DamageCalculation(weaponDamage);
            damageable.Damage(damage);

        }
    }

    public void EnableCollider()
    {
       
        if (collider != null)
        {
           collider.enabled = true;
        }
    }
    public void DisableCollider()
    {
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
}