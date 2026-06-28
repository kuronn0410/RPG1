using UnityEngine;
using System.Collections.Generic;

namespace RPG.Enemy
{

    //現状の敵のステータスを保存・設定するクラス
    public class CurrentEnemyStatus : MonoBehaviour
    {
        public static CurrentEnemyStatus Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            //初期化
            LevelUpEnemy(PlayerLevelData.StageLevel);
        }

        [SerializeField] EnemyDatabase enemyDatabase;
        //現在の敵のステータスを保存するリスト
        public List<EnemyParameter> currentEnemyParameters = new List<EnemyParameter>();

        //敵のレベルに応じてステータスを上げる
        //ステージクリア後に呼び出す
        public void LevelUpEnemy(int level)
        {
            currentEnemyParameters.Clear();

            foreach (EnemyParameter enemyParameter in enemyDatabase.enemies)
            {
                EnemyParameter copy = new EnemyParameter();

                copy.enemyType = enemyParameter.enemyType;
                copy.maxHp = enemyParameter.maxHp + (100 * (level - 1));
                copy.attack = enemyParameter.attack + (20 * (level - 1));
                copy.moveSpeed = enemyParameter.moveSpeed;
                copy.dropExp = enemyParameter.dropExp + (30 * (level - 1));
                copy.dropMoney = enemyParameter.dropMoney + (10 * (level - 1));

                currentEnemyParameters.Add(copy);

                Debug.Log(copy.enemyType + " ステータス更新");
            }
        }


    }


}
