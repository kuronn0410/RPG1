
using UnityEngine;
namespace RPG.Enemy
{
    [System.Serializable]
    public class BossParameter
    {
        public BossType bossType;
        public int maxHp;
        public int attack;
        public float moveSpeed;
        public int dropExp;
        public int dropMoney;
    }
}
