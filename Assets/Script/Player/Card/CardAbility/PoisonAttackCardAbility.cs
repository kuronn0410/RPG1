using UnityEngine;

public class PoisonAttackCardAbility : MonoBehaviour
{
    private bool isPoisoned = false;
    [SerializeField] private int poisonDamage = 10;
    [SerializeField] private float intervalTime = 6f;
    [SerializeField] private int repeatTimes = 3;

    [SerializeField] GameObject parentObject; // 武器の親オブジェクトを指定

    private void Awake()
    {
        if (parentObject == null)
        {
          Debug.Assert(parentObject != null, "親オブジェクトが設定されていません。"
              +"InspectorでparentObjectに武器の親オブジェクトを割り当ててください。");
        }
    }
    public void UsePoisonAttackCardAbility()
    {
        if(!isPoisoned)
        {

            WeaponDamage weaponDamage = parentObject.GetComponentInChildren<WeaponDamage>();
            if (weaponDamage != null)
            {
                weaponDamage.PoisonDamageOn(poisonDamage, intervalTime, repeatTimes);
                Debug.Log("毒攻撃カードの能力が発動しました！");
                isPoisoned = true;
            }
        }
        return;
    }
}
