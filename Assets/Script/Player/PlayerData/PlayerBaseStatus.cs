using UnityEngine;


[CreateAssetMenu
(
    fileName = "PlayerBaseStatus",
    menuName = "Player/PlayerBaseStatus"
)]
public class PlayerBaseStatus : ScriptableObject
{
    public int playerLevel;
    public int baseHp;
    public int baseDamage;
}
