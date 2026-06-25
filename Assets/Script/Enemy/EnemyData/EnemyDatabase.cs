using UnityEngine;
using System.Collections.Generic;

namespace RPG.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data")]
    public class EnemyDatabase : ScriptableObject
    {
        public List<EnemyParameter> enemies = new List<EnemyParameter>();
    }

}

