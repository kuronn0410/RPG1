using UnityEngine;
using RPG.Player;

namespace RPG.Enemy
{
    public class EnemyMove1 : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] float speed = 3f;
        [SerializeField] float rotationSpeed = 5f; // 回転速度を追加
                                                   //[SerializeField] Transform player;
        [SerializeField] float viewDistance = 10f;
        [SerializeField] float keepDistance = 2f;// プレイヤーとの距離を保つための変数
        private EnemyAttack enemyAttack;
        private Vector3 startPosition;

        [Header("Animation")]
        public bool IsMoving { get; private set; }
        private Transform player;
        public bool isStunned { get; private set; } // スタン状態かどうかのフラグ

        private bool isPlayerInvisible; // プレイヤーが透明化しているかどうかのフラグ

        void Start()
        {
            enemyAttack = GetComponent<EnemyAttack>();
            // プレイヤーのTransformを取得
            player = PlayerStatus.Instance.transform;

        }
        void Update()
        {

            move1();
        }


        void move1()
        {
            if (player == null) return;

            if (isStunned)
            {
                IsMoving = false; // スタン状態のときは移動を停止
                return;
            } // スタン状態なら移動しない 


            if (isPlayerInvisible)
            {
                IsMoving = false; // プレイヤーが透明化しているときは移動を停止
                return;
            } // プレイヤーが透明化しているときは移動しない

            float distance = Vector3.Distance(transform.position, player.position);
            Vector3 directionToPlayer = (player.position - transform.position).normalized;// プレイヤーへの方向を計算
            Vector3 rayStart = transform.position + Vector3.up * 0.5f;

            // 1. プレイヤーが視界内にいるか
            if (distance <= viewDistance)
            {

                // 基本的にはプレイヤーの方を向く（緩やかに回転）
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


                // 3. 移動実行
                if (distance > keepDistance)
                {
                    IsMoving = true;
                    transform.position += transform.forward * speed * Time.deltaTime;
                    // プレイヤーとの距離が近すぎる場合は停止

                    if (enemyAttack.isAttacking)
                    {
                        enemyAttack.StopAttack();
                    }
                }
                else
                {
                    IsMoving = false;

                    if (!enemyAttack.isAttacking)
                    {
                        enemyAttack.CactusAttack();
                    }
                }
            }
            else if (IsMoving)
            {
                IsMoving = false;
            }
        }

        /// <summary>
        /// スタン状態にする関数
        /// </summary>
        /// <param name="stunTime">スタン時間</param>
        public void StunState(float stunTime)
        {
            Debug.Log("スタン状態");
            isStunned = true;
            //IsMoving = false; // スタン状態になったら移動を停止
            Invoke(nameof(EndStun), stunTime);
        }

        public void EndStun()
        {
            Debug.Log("スタン状態解除");
            isStunned = false;

        }

        /// <summary>
        /// プレイヤーが透明化ポーションを使用したときに呼び出される関数
        /// </summary>
        public void PlayerTpPotion(float invisibilityTime)
        {
            isPlayerInvisible = true;
            Invoke(nameof(EndInvisibility), invisibilityTime);
        }

        private void EndInvisibility()
        {
            isPlayerInvisible = false;
        }

        void OnDrawGizmosSelected()
        {
            // 視界の範囲を表示
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, viewDistance);
        }
    }
}
