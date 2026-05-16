using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    private List<EnemyStatus> enemies = new List<EnemyStatus>();
    public void AddEnemy(EnemyStatus enemy)
    {
        enemies.Add(enemy);
        Debug.Log("“G’Ç‰Á: " + enemy.name);
    }
    public void RemoveEnemy(EnemyStatus enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            //GameManager.Instance.ResumeGame();
            Debug.Log("‘S“GŒ‚”j");
        }
    }

}
