using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] WeaponDatabase weaponDatabase;
    [SerializeField] WeaponType weaponType;
    private Collider weaponCollider;
    //private PlayerAttack playerAttack;
    private PlayerStatus playerStatus;
    private WeaponParameter weaponParameter;
    private int weaponDamage;
    [Header("毒攻撃用")]
    private bool isPoisonDamageActive = false; // 毒ダメージが有効かどうかのフラグ
    private int poisonDamage;
    private float poisonIntervalTime;
    private int repeatTimes;


    void Start()
    {
        weaponParameter = weaponDatabase.GetWeaponData(weaponType);
        weaponCollider = GetComponent<Collider>();
        //playerAttack = GetComponentInParent<PlayerAttack>();

        if(weaponCollider!=null)
        {
            weaponCollider.enabled = false;
        }
        
        playerStatus = GetComponentInParent<PlayerStatus>();
        weaponDamage = weaponParameter.damage;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        IDamageable damageable = other.GetComponent<IDamageable>();
        EnemyStatus enemyStatus = other.GetComponent<EnemyStatus>();
        if (damageable != null)
        {
            int damage = playerStatus.DamageCalculation(weaponDamage);
            damageable.Damage(damage);
            
            if (isPoisonDamageActive)
            {
                enemyStatus.PoisonDamage(poisonDamage, poisonIntervalTime, repeatTimes); // 毒ダメージを適用
                isPoisonDamageActive = false; // 毒ダメージの適用が完了したらフラグをリセット
            }
        }
    }

   

    public void PoisonDamageOn(int poisonDamage, float poisonIntervalTime, int repeatTimes)
    {
        this.poisonDamage = poisonDamage;
        this.poisonIntervalTime = poisonIntervalTime;
        this.repeatTimes = repeatTimes; // 毒ダメージの繰り返し回数を設定
        isPoisonDamageActive = true;
    }
    public void EnableCollider()
    {
       
        if (GetComponent<Collider>() != null)
        {
           GetComponent<Collider>().enabled = true;
        }
    }
    public void DisableCollider()
    {
        if (GetComponent<Collider>() != null)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}