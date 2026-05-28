using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] DoorChange doorChange;
    private List<EnemyStatus> enemies = new List<EnemyStatus>();

    private void Start()
    {
        if(doorChange != null)
        {
            doorChange.enabled = false;
        }
    }
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
            
            Debug.Log("‘S“GŒ‚”j");
            if (doorChange != null)
            {
                doorChange.enabled = true;
            }

        }
    }

}
