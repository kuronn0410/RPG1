using UnityEngine;

namespace RPG.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] Animator animator;

        private PlayerMove playerMove;
        private PlayerAttack playerAttack;

        void Start()
        {
            playerMove = GetComponent<PlayerMove>();
            playerAttack = GetComponent<PlayerAttack>();
        }

        void Update()
        {
            if (animator == null || playerMove == null || playerAttack == null)
            {
                return;
            }

            animator.SetBool("Run", playerMove.IsMoving);
            animator.SetBool("AttackNomal", playerAttack.IsAttacking);
        }

    }
}
