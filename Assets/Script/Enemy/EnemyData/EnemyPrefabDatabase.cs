using UnityEngine;
using System.Collections.Generic;

namespace RPG.Enemy
{
    [CreateAssetMenu(fileName = "EnemyPrefabDatabase", menuName = "Database/EnemyPrefabDatabase")]
    public class EnemyPrefabDatabase : ScriptableObject
    {
        public List<EnemyPrefabData> enemyPrefabs = new List<EnemyPrefabData>();
    }
}


    