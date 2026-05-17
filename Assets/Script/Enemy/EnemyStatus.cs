using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] EnemyDatabase enemyDatabase;

    public int remainHp;
    public int SaveMaxHP;
    private EnemyParameter enemyParameter;
    private EnemyManager enemyManager;

    private void Start()
    {
        enemyManager =FindFirstObjectByType<EnemyManager>();
        enemyManager.AddEnemy(this);
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
                remainHp= 0;
                enemyManager.RemoveEnemy(this); // 敵マネージャーからこの敵を削除
                // 敵が死亡した場合の処理をここに追加
                Debug.Log("Enemy defeated!");
                Destroy(gameObject); // 敵オブジェクトを破壊
            }
        }
    }
}
