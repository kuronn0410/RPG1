using UnityEngine;
using System.Collections.Generic;

namespace RPG.Enemy
{
    public class EnemyManager : MonoBehaviour
    {

        [SerializeField] DoorChange doorChange;
        [SerializeField] CurrentEnemyStatus currentEnemyStatus;

        private List<EnemyStatus> enemies = new List<EnemyStatus>();

        private void Start()
        {
            if (doorChange != null)
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
                    PlayerLevelData.StageLevel += 1;
                    if (PlayerLevelData.StageLevel == 4)
                    {
                        GameStateUI.Instance.VictoryPanel();
                    }
                    Debug.Log("EnemyƒŒƒxƒ‹ƒAƒbƒv: " + PlayerLevelData.StageLevel);
                    //currentEnemyStatus.LevelUpEnemy(PlayerLevelData.StageLevel);
                    doorChange.enabled = true;
                }

            }
        }

    }

}

