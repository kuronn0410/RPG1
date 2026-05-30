using UnityEngine;

public class AttackBoostCardAbility : MonoBehaviour
{

    [SerializeField] private int attackBoostAmount = 100; // UŒ‚—Í‚Ì‘‰Á—Ê
    public void UseAttackBoostCardAbility()
    {
        PlayerStatus.Instance.AttackUp(attackBoostAmount); // —á‚¦‚ÎAUŒ‚—Í‚ğ10‘‰Á‚³‚¹‚é
    }
}
