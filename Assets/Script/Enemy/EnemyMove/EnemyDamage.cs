using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.Enemy
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyDamage : MonoBehaviour
    {
        EnemyStatus enemyStatus;
        int damage;
       void Start()
        {
            //BoxCollider boxCollider = GetComponent<BoxCollider>();
            //boxCollider.isTrigger = true; // トリガーとして設定
            enemyStatus = GetComponentInParent<EnemyStatus>();
           
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (enemyStatus != null)
            {
                damage = enemyStatus.GetDamage(); // 敵の攻撃力を取得
            }
            if (damageable != null)
            {
                damageable.Damage(damage); // プレイヤーにダメージを与える
            }
        }
    }

}
