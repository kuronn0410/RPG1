using UnityEngine;

public class CardAbilityManeger : MonoBehaviour
{
   public static CardAbilityManeger Instance;
    void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    [SerializeField] private HealCardAbility healCardAbility;
    [SerializeField] private AttackBoostCardAbility attackBoostCardAbility;

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
        }
    }
}
