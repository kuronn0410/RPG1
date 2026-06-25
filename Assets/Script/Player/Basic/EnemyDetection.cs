using UnityEngine;

namespace RPG.Player
{
    /// <summary>
    /// 敵の検知を行うスクリプト
    /// </summary>
    public class EnemyDetection : MonoBehaviour
    {
        [SerializeField] private float detectionDistance = 5f;
        [SerializeField] private LayerMask enemyLayer;
        private EnemyStatus closestEnemy;
        private EnemyMove1 rengEnemyMove;

        private EnemyStatus previousEnemy;

        //int enemyLayer = LayerMask.GetMask("Enemy");
        public event System.Action<EnemyStatus> OnClosestEnemyDetected; // 敵が検知されたときに呼ばれるイベント
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
            EnemyStatus detectedEnemy = null;
            //closestEnemy = null;


            foreach (Collider hitCollider in hitColliders)
            {
                EnemyStatus enemy = hitCollider.GetComponent<EnemyStatus>();
                if (enemy != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    // より近い敵を見つけたら更新
                    if (distanceToEnemy < closestDistance)
                    {
                        closestDistance = distanceToEnemy;
                        detectedEnemy = enemy;
                    }

                }
            }
            closestEnemy = detectedEnemy;

            // 近くの敵が変わった時だけ通知
            if (previousEnemy != closestEnemy)
            {
                previousEnemy = closestEnemy;
                OnClosestEnemyDetected?.Invoke(closestEnemy);
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

}
