using UnityEngine;
namespace RPG.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        //int attackDamage = 10; // 攻撃のダメージ量
        public bool isAttacking { get; private set; } = false; // 攻撃中かどうかのフラグ
        private EnemyDamage enemyDamage; // 敵のダメージ処理を担当するクラスの参照    
        private Collider attackCollider; // 攻撃用のコライダーの参照

        void Start()
        {
            enemyDamage = GetComponentInChildren<EnemyDamage>();
            attackCollider = enemyDamage.GetComponent<Collider>();
        }
        public void CactusAttack()
        {
            isAttacking = true;
            attackCollider.enabled = true; // 攻撃用のコライダーを有効にする

        }

        public void StopAttack()
        {
            isAttacking = false;
            attackCollider.enabled = false; // 攻撃用のコライダーを無効にする
        }
    }
}


