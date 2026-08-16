using RPG.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Text hpText;
    [SerializeField] private Text expText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text weaponText;

    [SerializeField] private PlayerStatus playerStatus;

    private void OnEnable()
    {
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        levelText.text =
            $"Level: {PlayerLevelData.level}";

        hpText.text =
            $"HP: {PlayerLevelData.currentHp}" +
            $" / {playerStatus.SaveMaxHP}";

        int currentExp =
            PlayerLevelData.nextLevelExperience;

        int requiredExp =
            100 * PlayerLevelData.level;

        expText.text =
            $"EXP: {currentExp} / {requiredExp}";

        moneyText.text =
            $"Money: {PlayerLevelData.money}";

        weaponText.text =
            $"Weapon: {PlayerLevelData.currentWeaponType}";
    }

}
