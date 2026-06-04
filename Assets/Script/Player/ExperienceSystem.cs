using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
   
    [SerializeField] private PlayerStatus playerStatus;
    public event System.Action<int> OnLevelUp;
    public event System.Action<int> OnExperienceAdded;

    private void Awake()
    {
        //インスペクターで設定されていることを確認
        Debug.Assert(playerStatus != null, "ExperienceSystem: playerStatus が設定されていません");

    }

    public void AddExperience(int exp)
    {
        PlayerLevelData.nextLevelExperience += exp;
        if (PlayerLevelData.nextLevelExperience >= 100 * PlayerLevelData.level) // Example threshold for leveling up
        {
            PlayerLevelData.nextLevelExperience -= 100 * PlayerLevelData.level; // Set next level experience threshold
            OnExperienceAdded?.Invoke(PlayerLevelData.nextLevelExperience);
            LevelUp();
        }
    }

    void LevelUp()
    {
        PlayerLevelData.level++;
        playerStatus.LevelUpAndLoadData(PlayerLevelData.level);
        playerStatus.LevelUpHeal(); // レベルアップ時にHPを全回復
        OnLevelUp?.Invoke(PlayerLevelData.level);
    }
}
