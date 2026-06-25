using UnityEngine;
using RPG.Player;

public class TpPotionCardAbility : MonoBehaviour
{

    [SerializeField] private float tpPotionTime = 15f;
    [SerializeField] private float tpPotionRange = 20f;
    [SerializeField] EnemyDetection enemyDetection;

    private void Awake()
    {
       Debug.Assert(enemyDetection != null, "TpPotionCardAbilityにEnemyDetectionがinspectorで指定されていません");
    }

    public void UseTpPotionCardAbility()
    {
        enemyDetection.PlayerTpPotionRange(tpPotionRange, tpPotionTime);
        return;
    }
}
