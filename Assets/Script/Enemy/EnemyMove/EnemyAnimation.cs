using UnityEngine;

namespace RPG.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] Animator animator;
        private EnemyMove1 enemyMove;
        private EnemyAttack enemyAttack;
        void Start()
        {
            enemyMove = GetComponent<EnemyMove1>();
            enemyAttack = GetComponent<EnemyAttack>();

        }

        // Update is called once per frame
        void Update()
        {
            if (enemyAttack == null || enemyMove == null)
            {
                return;
            }
            animator.SetBool("Run", enemyMove.IsMoving);

            animator.SetBool("AttackNormal", enemyAttack.isAttacking);

            animator.SetBool("Stun", enemyMove.isStunned);


        }
    }

}
