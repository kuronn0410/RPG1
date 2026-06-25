using UnityEngine;
using RPG.Player;

public class StunAttackCardAbility : MonoBehaviour
{
    [SerializeField] private EnemyDetection enemyDetection;
    [SerializeField] private float stunTime = 2f;
    [SerializeField] private float stunRange = 10f;

    private void Awake()
    {
        if (enemyDetection == null)
        {
            Debug.Assert(false, "StunAttackCardAbilityにEnemyDetectionがアタッチされていません。");
        }
    }

    public void UseStunAttackCardAbility()
    {
        enemyDetection.RangeinEnemy(stunRange, stunTime); // 範囲内の敵を取得
        return;
    }
}
