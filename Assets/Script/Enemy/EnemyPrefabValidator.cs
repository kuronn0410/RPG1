using RPG.Enemy;
using UnityEngine;

/*
 [RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioSource))]
 */
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(EnemyStatus))]
[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyAudio))]
public class EnemyPrefabValidator : MonoBehaviour
{

    [SerializeField] EnemyDamage[] enemyDamage;
    private EnemyMove1 enemyMove;  
    private EnemyDamagePos enemyDamagePos;
    
    void Awake()
    {
        enemyMove ??= GetComponentInChildren<EnemyMove1>();
        enemyDamagePos ??= GetComponentInChildren<EnemyDamagePos>();
        //enemyStatus ??= GetComponentInChildren<EnemyStatus>();

        Check(enemyMove, nameof(enemyMove));
        Check(enemyDamagePos, nameof(enemyDamagePos));
        //Check(enemyStatus, nameof(enemyStatus));
    }

    private void Check(Object target, string fieldName)
    {
        if (target == null)
        {
            Debug.LogError($"{name} の {fieldName} が設定されていません", this);
        }
    }
}
