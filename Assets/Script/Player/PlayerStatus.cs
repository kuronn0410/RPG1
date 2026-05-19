using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{

    [Header("Player HP")]
    public int SaveMaxHP;//表示用
    public int remainHp;
    private int baseDamage; // ダメージ量を保存する変数
    public int dealingDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveMaxHP = PlayerLevelData.maxHp;
        remainHp = PlayerLevelData.maxHp;
        baseDamage = PlayerLevelData.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        Debug.Log("Take " + damage + " damage!");
        // Here you can implement health reduction, death, etc.
        if (remainHp > 0)
        {
            remainHp -= damage; // ダメージをHPから減算
            if (remainHp <= 0)
            {
                remainHp = 0;
                Debug.Log("Player defeated!");
            }
        }
    }

    public void Heal()
    {
        SaveMaxHP = PlayerLevelData.maxHp;
        remainHp = PlayerLevelData.maxHp;
        baseDamage = PlayerLevelData.damage;
    }

    //武器側に与えるダメージを計算するための関数
    public int DamageCalculation(int weapponDamage)
    {
        dealingDamage = baseDamage + weapponDamage; // 武器のダメージを保存

        return dealingDamage;
    }

}
