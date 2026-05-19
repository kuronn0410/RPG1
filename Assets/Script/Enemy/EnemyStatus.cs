using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] EnemyDatabase enemyDatabase;

    public int remainHp;
    public int SaveMaxHP;
    public int dropExp;
    public int dropMoney; // ドロップマネーを保存する変数
    private EnemyParameter enemyParameter;
    private EnemyManager enemyManager;
    private ExperienceSystem experienceSystem;
    private MoneySystem moneySystem;

    bool isDead = false;

    private void Start()
    {
        enemyManager = FindFirstObjectByType<EnemyManager>();
        enemyManager.AddEnemy(this);
        experienceSystem = FindFirstObjectByType<ExperienceSystem>();
        moneySystem = FindFirstObjectByType<MoneySystem>(); // マネーシステムを取得
        switch (enemyType)
        {
            case EnemyType.Saboten:
                enemyParameter = enemyDatabase.enemies[0]; // サボテンのパラメータを取得
                break;
            case EnemyType.Kinoko:
                enemyParameter = enemyDatabase.enemies[1]; // キノコのパラメータを取得
                break;
            default:
                break;
        }
        SaveMaxHP = enemyParameter.maxHp; // 最大HPを保存
        remainHp = enemyParameter.maxHp; // 敵のHPを初期化
        dropExp = enemyParameter.dropExp; // ドロップ経験値を保存
        dropMoney = enemyParameter.dropMoney; // ドロップマネーを保存

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
