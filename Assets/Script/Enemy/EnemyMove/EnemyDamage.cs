using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.Enemy
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyDamage : MonoBehaviour
    {

        [SerializeField] int damage = 10;
        void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damage); // プレイヤーにダメージを与える
            }
        }
    }

}
