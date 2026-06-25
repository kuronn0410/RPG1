using UnityEngine;
using RPG.Player;

public class HealCardAbility : MonoBehaviour
{
    public void UseHealCardAbility()
    {
        PlayerStatus.Instance.Heal();
    }
}
