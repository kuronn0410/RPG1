using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType enemyType;
    //[SerializeField] EnemyDatabase enemyDatabase;

    public int remainHp;
    public int SaveMaxHP;
    public int dropExp;
    public int dropMoney; // ドロップマネーを保存する変数
    private EnemyParameter enemyParameter;
    private EnemyManager enemyManager;
    private ExperienceSystem experienceSystem;
    private MoneySystem moneySystem;

    bool isDead = false;


    public void SetUpEnemyStatus()
    {
       foreach(EnemyParameter enemyParameter in CurrentEnemyStatus.currentEnemyParameters)
       {
           if(enemyParameter.enemyType == enemyType)
           {
               remainHp = enemyParameter.maxHp;
               SaveMaxHP = enemyParameter.maxHp;
               dropExp = enemyParameter.dropExp;
               dropMoney = enemyParameter.dropMoney;
                Debug.Log(enemyType + " 生成時HP: " + remainHp);
                break;

            }
       }
    }

    private void Start()
    {
        enemyManager = FindFirstObjectByType<EnemyManager>();
        enemyManager.AddEnemy(this);
        experienceSystem = FindFirstObjectByType<ExperienceSystem>();
        moneySystem = FindFirstObjectByType<MoneySystem>(); // マネーシステムを取得
    }


    public void Damage(int damage)
    { 
        if (isDead) return;
        Debug.Log("Take " + damage + " damage!");
        // Here you can implement health reduction, death, etc.
        if (remainHp > 0)
        {
            remainHp -= damage; // ダメージをHPから減算
            if (remainHp <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        if(isDead) return; // すでに死亡している場合は処理を行わない
        remainHp = 0;
        isDead = true; // 敵が死亡したことを記録
        enemyManager.RemoveEnemy(this); // 敵マネージャーからこの敵を削除
        Debug.Log("Enemy defeated!");
        experienceSystem.AddExperience(dropExp); // 経験値を加算
        moneySystem.AddMoney(dropMoney); // マネーを加算
        Debug.Log("Destroyする : " + gameObject.name);
        Destroy(gameObject); // 敵オブジェクトを破壊
    }

}
