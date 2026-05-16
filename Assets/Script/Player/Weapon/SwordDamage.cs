using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private Collider collider;
    //private PlayerAttack playerAttack;

    void Start()
    {
        collider = GetComponent<Collider>();
        //playerAttack = GetComponentInParent<PlayerAttack>();
        if(collider!=null)
        {
            collider.enabled = false;
        }
    }
    private int damage = 20;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
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