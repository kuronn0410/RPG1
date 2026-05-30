using UnityEngine;

public class HealCardAbility : MonoBehaviour
{
    public void UseHealCardAbility()
    {
        PlayerStatus.Instance.Heal();
    }
}
