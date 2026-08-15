using RPG.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Enemy
{
    [CreateAssetMenu(fileName = "New Boss Data", menuName = "Boss Data")]
    public class BossDatabase : ScriptableObject
    {
        public List<BossParameter> enemies = new List<BossParameter>();

    }
}