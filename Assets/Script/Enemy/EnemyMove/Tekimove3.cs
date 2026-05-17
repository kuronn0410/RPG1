using UnityEngine;

public class Tekimove3 : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // 敵の移動速度
    //[SerializeField]
    [SerializeField] Transform[] waypoints;
    private int i = 0; // 現在のウェイポイントのインデックス
    private  int count = 0; // ウェイポイントの数

    private float distanse;
    private Vector3 direction;
    
    void Start()
    {
        //一つ目のウェイポイントに向かって回転する
        count = waypoints.Length;
        //LookAtTarget();
    }

    void Update()
    {
        if(count == 0) return; // ウェイポイントがない場合は何もしない
        move3();

    }

    void move3()
    {
        Vector3 targetPos = waypoints[i].position;
        targetPos.y = transform.position.y;
        direction = (targetPos - transform.position).normalized;
        distanse = Vector3.Distance(transform.position, targetPos);
        if (distanse > 0.5f)
        {
            // 現在のウェイポイントに向かって移動する
            transform.position += direction * speed * Time.deltaTime;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);

            }

        }
        else
        {
            i++;
            if (i >= count)
            {
                i = 0;
            }


            //LookAtTarget();

        }
    }

    /*void LookAtTarget()
    {
        Vector3 targetPos = waypoints[i].position;
        targetPos.y = transform.position.y;
        direction = targetPos - transform.position;
        if(direction!= Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);

        }
        

    }
    */

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;
        Gizmos.color = Color.red;

        for (int n = 0; n < waypoints.Length; n++)
        {
            Vector3 current = waypoints[n].position;
            Vector3 next = waypoints[(n + 1) % waypoints.Length].position;
            Gizmos.DrawLine(current, next);
        }
    }
     
}
