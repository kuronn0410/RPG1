using UnityEngine;
using System.Collections.Generic;

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

            if (currentEnemyParameters.Count == 0)
            {
                InitialSet();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }



    [SerializeField] EnemyDatabase enemyDatabase;
    //現在の敵のステータスを保存するリスト
    public static List<EnemyParameter> currentEnemyParameters = new List<EnemyParameter>();
    /*
   private void Start()
   {
       InitialSet();
   }
    */

    //敵のステータスを初期化する
    private void InitialSet()
    {
        currentEnemyParameters.Clear();
        foreach (EnemyParameter enemyParameter in enemyDatabase.enemies)
        {
            EnemyParameter copy = new EnemyParameter();

            copy.enemyType = enemyParameter.enemyType;
            copy.maxHp = enemyParameter.maxHp;
            copy.attack = enemyParameter.attack;
            copy.moveSpeed = enemyParameter.moveSpeed;
            copy.dropExp = enemyParameter.dropExp;
            copy.dropMoney = enemyParameter.dropMoney;

            currentEnemyParameters.Add(copy);
        }
      
    }

    //敵のレベルに応じてステータスを上げる
    //ステージクリア後に呼び出す
    public void LevelUpEnemy(int level)
    {
        foreach(EnemyParameter enemyParameter in currentEnemyParameters)
        {

             enemyParameter.maxHp += 100*level;
             enemyParameter.attack += 20*level;
             //enemyParameter.moveSpeed += 0.1f*level;
             enemyParameter.dropExp += 30*level;
             enemyParameter.dropMoney += 10*level;
           Debug.Log("ステータスがレベルアップ");

        }
    }


}
