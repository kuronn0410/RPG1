using UnityEngine;

public class EnemyMove1 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 3f;
    [SerializeField] float rotationSpeed = 5f; // 回転速度を追加
    [SerializeField] Transform player;
    [SerializeField] float viewDistance = 10f;
    [SerializeField] float keepDistance = 2f;// プレイヤーとの距離を保つための変数
    private Vector3 startPosition;

    [Header("Pointer")]
    private int count = 0; // ウェイポイントの数
    private bool isAvoiding = false;
    private int savedPointerIndex = 0; // 【追加】決めた目標を覚えておくための変数
    private Transform[] waypoints;

    [Header("Animation")]
    public bool IsMoving { get; private set; }


    void Start()
    {
       startPosition = transform.position;
       GameObject[] PointersAll = GameObject.FindGameObjectsWithTag("Pointer");
       count =PointersAll.Length;
       waypoints = new Transform[count];
        for (int i = 0; i < count; i++)
       {
         waypoints[i] = PointersAll[i].transform;
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

            if (isAvoiding)
            {
                PointerMove(savedPointerIndex);
            }
            else
            {
                // 基本的にはプレイヤーの方を向く（緩やかに回転）
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // 2. 前方に壁がある場合の回避処理
                RaycastHit hit;
                if (Physics.Raycast(rayStart, transform.forward, out hit, 1.5f))
                {

                    if (hit.collider.CompareTag("wall"))
                    {
                        isAvoiding = true;
                        savedPointerIndex = GetPlayerClosePointer();
                        return;// 回避開始

                    }


                }

                // 3. 移動実行
                // 前方が完全に塞がっていない時だけ進む（必要に応じて調整）
                if(distance>keepDistance)
                {
                                        IsMoving = true;
                    transform.position += transform.forward * speed * Time.deltaTime;
                    // プレイヤーとの距離が近すぎる場合は停止
                   
                }
                else
                {
                    IsMoving = false;
                }

            }
        }
        else if(IsMoving)
        {
           IsMoving = false;
        }


    }

    

    void PointerMove(int closestPointer)
    {
        float pointerdistanse;
        Vector3 pointerdirection;       
        Vector3 targetPos = waypoints[closestPointer].position;
        targetPos.y = transform.position.y;
        pointerdirection = (targetPos - transform.position).normalized;
        pointerdistanse = Vector3.Distance(transform.position, targetPos);
        if (pointerdistanse > 0.5f)
        {

            if (pointerdirection != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(pointerdirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
            }
            // 現在のウェイポイントに向かって移動する
            transform.position += pointerdirection * speed * Time.deltaTime;
        }
        else
        {
           isAvoiding = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        // 視界の範囲を表示
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    int GetPlayerClosePointer()
    {
       int bestIndex = 0;   
       float closestDistance = float.MaxValue;
        for (int i = 0; i < count; i++)
        {
           float distance = Vector3.Distance(player.position, waypoints[i].position);
           if (distance < closestDistance)
           {
               closestDistance = distance;
               bestIndex = i;
           }
        }

        //Debug.Log("最も近いウェイポイントのインデックス: " + bestIndex);
        return bestIndex;
    }
    
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = startPosition;
            // プレイヤーにダメージを与える処理をここに追加
            Debug.Log("プレイヤーにダメージを与えました！");
        }
    }
    */
}