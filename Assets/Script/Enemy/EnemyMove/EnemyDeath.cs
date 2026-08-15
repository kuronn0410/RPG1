using UnityEngine;
using System.Collections;
using System;

namespace RPG.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyStatus enemyStatus;
        private Transform visual;
        private EnemyMove1 enemyMove;
        [SerializeField] float deathAnimationTime = 1.0f; // 死亡アニメーションの再生時間
        private void Awake()
        {
            enemyStatus = GetComponent<EnemyStatus>();
            if (enemyStatus != null)
            {
                enemyStatus.OnEnemyDeath += HandleEnemyDeath;
            }
            visual = GetComponent<Transform>();
            enemyMove = GetComponent<EnemyMove1>();

        }
        private void OnDestroy()
        {
            if (enemyStatus != null)
            {
                enemyStatus.OnEnemyDeath -= HandleEnemyDeath;
            }
        }


        private void HandleEnemyDeath()
        {
            // 敵が死亡したときの処理をここに記述
            Debug.Log("敵が死亡しました: " + gameObject.name);
            enemyMove?.DestroyEnemy(deathAnimationTime);
            StartCoroutine(DeathCoroutine());
            //Destroy(gameObject);
        }

        private IEnumerator DeathCoroutine()
        {
            Vector3 initialScale = visual.localScale;
            float elapsedTime = 0f;

            while (elapsedTime < deathAnimationTime)
            {
                elapsedTime += Time.deltaTime;
                float progress = Mathf.Clamp01(elapsedTime / deathAnimationTime);

                visual.localScale =
                    Vector3.Lerp(initialScale, Vector3.zero, progress);

                yield return null;
            }

            Destroy(gameObject);
            enemyStatus.EnemyRemove();

        }
    }
}

