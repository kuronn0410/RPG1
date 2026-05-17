using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //int attackDamage = 10; // 攻撃のダメージ量
    public bool isAttacking { get; private set; } = false; // 攻撃中かどうかのフラグ
    public void CactusAttack()
    {
        isAttacking = true;
    }
    
    public void StopAttack()
    {
        isAttacking = false;
    }
}
