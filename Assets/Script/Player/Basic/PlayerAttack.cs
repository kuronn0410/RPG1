using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    private WeaponDamage weaponDamage;

    void Start()
    {
        IsAttacking = false;
        //weaponDamage = GetComponentInChildren<WeaponDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SwordAttackTrue();
        }
        if(Input.GetMouseButtonUp(0))
        {
            SwordAttackFalse();
        }   

    }

    private void SwordAttackTrue()
    {
        IsAttacking = true;
        if (weaponDamage != null)
        {
            weaponDamage.EnableCollider();
        }


    }
    
    private void SwordAttackFalse()
    {
        IsAttacking = false;
        if (weaponDamage != null)
        {
            weaponDamage.DisableCollider();
        }
    }

    public void SetWeaponDamage(WeaponDamage wd)
    {
        weaponDamage = wd;
    }
}
