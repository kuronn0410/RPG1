using UnityEngine;

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


    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        player    = PlayerStatus.Instance.transform;
        if (playerStatus != null)
        {
            player = playerStatus.transform;
        }
        else
        {
            Debug.LogError("PlayerStatusが見つかりませんでした。");
        }

    }
    void Update()
    {
        
        move1();
    }

    
    void move1()
    {
        if (player == null) return;



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
                if(distance>keepDistance)
                {
                    IsMoving = true;
                    transform.position += transform.forward * speed * Time.deltaTime;
                    // プレイヤーとの距離が近すぎる場合は停止
                    
                    if(enemyAttack.isAttacking)
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
        else if(IsMoving)
        {
           IsMoving = false;
        }


    }
    void OnDrawGizmosSelected()
    {
        // 視界の範囲を表示
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

   
}