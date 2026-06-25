using UnityEngine;
using System.Collections.Generic;

namespace RPG.Enemy
{

    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] EnemyPrefabDatabase enemyPrefabDatabase;
        [SerializeField] Transform[] spawnPoints;
        [SerializeField] int numberOfEnemiesToSpawn = 5;

        private List<EnemyStatus> spawnedEnemies = new List<EnemyStatus>();


        private void Start()
        {
            RandomSpawnEnemies();
        }

        private void RandomSpawnEnemies()
        {
            List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);
            int spawnCount = Mathf.Min(numberOfEnemiesToSpawn, availableSpawnPoints.Count);

            for (int i = 0; i < spawnCount; i++)
            {
                int randomIndex = Random.Range(0, enemyPrefabDatabase.enemyPrefabs.Count);
                //ここでランダムに敵のプレハブを選択
                EnemyPrefabData prefabData = enemyPrefabDatabase.enemyPrefabs[randomIndex];
                GameObject enemyToSpawn = prefabData.enemyPrefab;

                //生成先のスポーンポイントをランダムに選択
                int spawnPointIndex = Random.Range(0, availableSpawnPoints.Count);
                Transform spawnPoint = availableSpawnPoints[spawnPointIndex];
                availableSpawnPoints.RemoveAt(spawnPointIndex);

                GameObject spawnedEnemyObject = Instantiate(
                    enemyToSpawn,
                    spawnPoint.position,
                    spawnPoint.rotation
                );
                //生成した敵オブジェクトからEnemyStatusコンポーネントを取得
                EnemyStatus spawnedEnemy = spawnedEnemyObject.GetComponent<EnemyStatus>();

                if (spawnedEnemy != null)
                {
                    spawnedEnemy.SetUpEnemyStatus();
                    Debug.Log("敵を生成: ");
                    spawnedEnemies.Add(spawnedEnemy);
                }
                else
                {
                    Debug.LogError("生成したPrefabにEnemyStatusが付いていません");
                }

            }
        }
    }
}
