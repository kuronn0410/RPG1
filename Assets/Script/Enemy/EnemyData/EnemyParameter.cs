using UnityEngine;
namespace RPG.Enemy
{
    [System.Serializable]
    public class EnemyParameter
    {
        public EnemyType enemyType;
        public EnemyRole enemyRole;
        public int maxHp;
        public int attack;
        public float moveSpeed;
        public int dropExp;
        public int dropMoney;
        //public GameObject prefab;
    }
}


