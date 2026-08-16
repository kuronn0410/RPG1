using UnityEngine;
namespace RPG.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        //int attackDamage = 10; // 攻撃のダメージ量
        public bool isAttacking { get; private set; } = false; // 攻撃中かどうかのフラグ
        private EnemyDamage enemyDamage; // 敵のダメージ処理を担当するクラスの参照    
        private Collider attackCollider; // 攻撃用のコライダーの参照

        private void Awake()
        {
            enemyDamage =
                GetComponentInChildren<EnemyDamage>(true);

            if (enemyDamage == null)
            {
                Debug.LogError(
                    $"{name}: 子にEnemyDamageがありません。",
                    this
                );

                enabled = false;
                return;
            }

            attackCollider =
                enemyDamage.GetComponent<Collider>();

            if (attackCollider == null)
            {
                Debug.LogError(
                    $"{name}: EnemyDamageと同じGameObjectにColliderがありません。",
                    enemyDamage
                );

                enabled = false;
                return;
            }

            // ゲーム開始直後は攻撃判定を無効化
            attackCollider.enabled = false;
        }

        //void Start()
        //{
        //    enemyDamage = GetComponentInChildren<EnemyDamage>();
        //    attackCollider = enemyDamage.GetComponent<Collider>();
        //}
        public void CactusAttack()
        {
            if (attackCollider == null)
            {
                Debug.LogError(
                    $"{name}: attackColliderが取得できていません。",
                    this
                );
                return;
            }

            isAttacking = true;
            attackCollider.enabled = true;
        }

        public void StopAttack()
        {
            isAttacking = false;

            if (attackCollider != null)
            {
                attackCollider.enabled = false;
            }

        }
    }
}


