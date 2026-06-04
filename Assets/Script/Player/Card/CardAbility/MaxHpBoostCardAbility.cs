using UnityEngine;

public class MaxHpBoostCardAbility : MonoBehaviour
{

   [SerializeField]private int maxHpBoostAmount;

   public void UseMaxHpBoostCardAbility()
   {
        PlayerStatus.Instance.MaxHpUp(maxHpBoostAmount);
   }
}
