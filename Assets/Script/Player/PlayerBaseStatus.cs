using UnityEngine;


[CreateAssetMenu
(
    fileName = "PlayerBaseStatus",
    menuName = "Player/PlayerBaseStatus"
)]
public class PlayerBaseStatus : ScriptableObject
{
    public int baseHp;
    public int baseMp;
    public int baseDamage;
    public int baseDefense;
}
