using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    private Collider collider;
    //private PlayerAttack playerAttack;
    private PlayerStatus playerStatus;
    private int weaponDamage;
    
    void Start()
    {
        collider = GetComponent<Collider>();
        //playerAttack = GetComponentInParent<PlayerAttack>();
        if(collider!=null)
        {
            collider.enabled = false;
        }
        
        playerStatus = GetComponentInParent<PlayerStatus>();

        weaponDamage = weaponData.damage;
        

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