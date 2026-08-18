using UnityEngine;
using System.Collections.Generic;

namespace RPG.Enemy
{
    //
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] EnemyPrefabDatabase enemyPrefabDatabase;
        [SerializeField] Transform[] spawnPoints;
        [SerializeField] Transform bossSpawnPoint;
        [SerializeField] int numberOfEnemiesToSpawn = 5;

        private List<EnemyStatus> spawnedEnemies = new List<EnemyStatus>();
        private int stageLevel = 1;

        private void Start()
        {
            stageLevel = PlayerLevelData.StageLevel;//後で直す
            RandomSpawnEnemies();
        }

        private void RandomSpawnEnemies()
        {
            List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);
            int spawnCount = Mathf.Min(numberOfEnemiesToSpawn, availableSpawnPoints.Count);

            if (stageLevel == 3)
            {
                List<EnemyPrefabData> bossEnemies = GetBossEnemies();
                if (bossEnemies.Count > 0)
                {
                    int bossRandomIndex = Random.Range(0, bossEnemies.Count);
                    EnemyPrefabData bossPrefabData = bossEnemies[bossRandomIndex];
                    GameObject bossenemyToSpawn = bossPrefabData.enemyPrefab;
                    GameObject spawnedBossEnemyObject = Instantiate(
                        bossenemyToSpawn,
                        bossSpawnPoint.position,
                        bossSpawnPoint.rotation
                    );

                    EnemyStatus spawnedBossEnemyStatus = spawnedBossEnemyObject.GetComponent<EnemyStatus>();
                    if (spawnedBossEnemyStatus != null)
                    {
                        spawnedBossEnemyStatus.SetUpEnemyStatus();
                        //Debug.Log("敵を生成: ");
                        spawnedEnemies.Add(spawnedBossEnemyStatus);
                    }
                    else
                    {
                        Debug.LogError("生成したPrefabにEnemyStatusが付いていません");
                    }
                }
            }

            for (int i = 0; i < spawnCount; i++)
            {
                

                List < EnemyPrefabData > normalEnemies = GetNormalEnemies();
                int randomIndex = Random.Range(0, normalEnemies.Count);
                //ここでランダムに敵のプレハブを選択
                EnemyPrefabData prefabData = normalEnemies[randomIndex];

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
                    //Debug.Log("敵を生成: ");
                    spawnedEnemies.Add(spawnedEnemy);
                }
                else
                {
                    Debug.LogError("生成したPrefabにEnemyStatusが付いていません");
                }

            }
        }


        public List<EnemyPrefabData> GetNormalEnemies()
        {
            List<EnemyPrefabData> nomalenemies = new List<EnemyPrefabData>();
            foreach(EnemyPrefabData data in enemyPrefabDatabase.enemyPrefabs)
            {
                if (data.enemyRole == EnemyRole.Normal)
                {
                    nomalenemies.Add(data);
                }
            }
            return nomalenemies;
        }

        public List<EnemyPrefabData> GetBossEnemies()
        {
            List<EnemyPrefabData> bossenemies = new List<EnemyPrefabData>();
            foreach(EnemyPrefabData data in enemyPrefabDatabase.enemyPrefabs)
            {
                if (data.enemyRole == EnemyRole.Boss)
                {
                    bossenemies.Add(data);
                }
            }
            return bossenemies;
        }
    }
}
