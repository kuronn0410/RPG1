using UnityEngine;

/// <summary>
/// 敵の検知を行うスクリプト
/// </summary>
public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private LayerMask enemyLayer;
    private EnemyStatus closestEnemy;
    private EnemyMove1 rengEnemyMove;
    public int SaveHP;
    public int SaveMaxHP;
    //int enemyLayer = LayerMask.GetMask("Enemy");

    void Update()
    {
        DetectEnemy();
    }

    /// <summary>
    /// 一番近い敵との距離
    /// </summary>
    private void DetectEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionDistance, enemyLayer);
        float closestDistance = detectionDistance;
        SaveHP = 0;
        SaveMaxHP = 0;
        closestEnemy = null;


        foreach (Collider hitCollider in hitColliders)
        {
            EnemyStatus enemy = hitCollider.GetComponent<EnemyStatus>();
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                    SaveHP = closestEnemy.remainHp;
                    SaveMaxHP = closestEnemy.SaveMaxHP;
                }
                    
            }
        }
        
    }

    /// <summary>
    /// 範囲内の敵の動きを管理してるスクリプトを取得するための関数
    /// </summary>
    /// <param name="range">範囲内</param>
    /// <param name="stunTime">スタン時間</param>
    public void RangeinEnemy(float range, float stunTime)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyLayer);
        //float closestDistance = range;
        foreach (Collider hitCollider in hitColliders)
        {
            EnemyMove1 enemy = hitCollider.GetComponent<EnemyMove1>();
            if (enemy != null)
            {
                enemy.StunState(stunTime);
            }
        }
    }


    /// <summary>
    /// すべての敵を検知する関数
    /// </summary>
    public void PlayerTpPotionRange(float range, float topotionTime)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyLayer);
        //float closestDistance = range;
        foreach (Collider hitCollider in hitColliders)
        {
            EnemyMove1 enemy = hitCollider.GetComponent<EnemyMove1>();
            if (enemy != null)
            {
                enemy.PlayerTpPotion(topotionTime);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }   
}