using System.Collections.Generic;
using UnityEngine;

namespace RPG.Enemy
{
    [CreateAssetMenu(fileName = "New Boss Prefab Data", menuName = "Boss Prefab Data")]
    public class BossPrefabDatabase : ScriptableObject
    {
        public List<BossPrefabData> bossPrefabs = new List<BossPrefabData>();
    }
}
