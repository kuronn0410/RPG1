using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "EnemyPrefabDatabase", menuName = "Database/EnemyPrefabDatabase")]
public class EnemyPrefabDatabase : ScriptableObject
{
    public List<EnemyPrefabData> enemyPrefabs = new List<EnemyPrefabData>();
}
    