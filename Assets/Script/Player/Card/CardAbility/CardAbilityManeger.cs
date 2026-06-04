using UnityEngine;

public class CardAbilityManeger : MonoBehaviour
{
    public static CardAbilityManeger Instance;

    [SerializeField] private HealCardAbility healCardAbility;
    [SerializeField] private AttackBoostCardAbility attackBoostCardAbility;
    [SerializeField] private PoisonAttackCardAbility poisonAttackCardAbility;
    [SerializeField] private StunAttackCardAbility stunAttackCardAbility; 
    [SerializeField] private MaxHpBoostCardAbility maxHpBoostCardAbility;
    [SerializeField] private TpPotionCardAbility tpPotionCardAbility;

    void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        Debug.Assert(healCardAbility != null, "HealCardAbilityがinspectorに設定されていません。");
        Debug.Assert(attackBoostCardAbility != null, "AttackBoostCardAbilityがinspectorに設定されていません。");
        Debug.Assert(poisonAttackCardAbility != null, "PoisonAttackCardAbilityがinspectorに設定されていません。");
        Debug.Assert(stunAttackCardAbility != null, "StunAttackCardAbilityがinspectorに設定されていません。");
        Debug.Assert(maxHpBoostCardAbility != null, "MaxHpBoostCardAbilityがinspectorに設定されていません。");
        Debug.Assert(tpPotionCardAbility != null, "TpPotionCardAbilityがinspectorに設定されていません。");


    }

    


    public void UseCardAbility(CardType cardType)
    {
        switch (cardType)
        {
            case CardType.HealPotion:
                healCardAbility.UseHealCardAbility();
                break;
            case CardType.AttackBoost:
                attackBoostCardAbility.UseAttackBoostCardAbility();
                break;
            case CardType.PoisonAttack:
                poisonAttackCardAbility.UsePoisonAttackCardAbility();
                break;
            case CardType.StunAttack:
                stunAttackCardAbility.UseStunAttackCardAbility();
                break;
            case CardType.MaxHpBoost:
                maxHpBoostCardAbility.UseMaxHpBoostCardAbility();
                break;
            case CardType.TransparencyPotion:
                tpPotionCardAbility.UseTpPotionCardAbility();
                break;
            default:
                Debug.LogWarning("未対応のカードタイプ: " + cardType);
                break;
        }
    }
}
