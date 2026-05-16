using UnityEngine;

public class hit : MonoBehaviour
{
  void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            // ここでプレイヤーにダメージを与えるなどの処理を行うことができます。
        }
    }
}
