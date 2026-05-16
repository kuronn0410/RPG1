using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    private SwordDamage swordDamage;

    void Start()
    {
        IsAttacking = false;
        swordDamage = GetComponentInChildren<SwordDamage>();
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
        if (swordDamage != null)
        {
            swordDamage.EnableCollider();
        }


    }
    
    private void SwordAttackFalse()
    {
        IsAttacking = false;
        if (swordDamage != null)
        {
            swordDamage.DisableCollider();
        }
    }
}
