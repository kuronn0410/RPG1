using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public int SaveLevel;
    public int SaveExperience = 0;
    [SerializeField] PlayerBaseStatus playerBaseStatus;
    void Start()
    {
        
        
    }

    public void AddExperience(int exp)
    {
        PlayerLevelData.nextLevelExperience += exp;
        if (PlayerLevelData.nextLevelExperience >= 100 * PlayerLevelData.level) // Example threshold for leveling up
        {
            PlayerLevelData.nextLevelExperience -= 100 * PlayerLevelData.level; // Set next level experience threshold
            LevelUp();
        }
    }

    void LevelUp()
    {
        PlayerLevelData.level++;
        PlayerStatus.Instance.LevelUpAndLoadData(PlayerLevelData.level);
        PlayerStatus.Instance.LevelUpHeal(); // レベルアップ時にHPを全回復
    }
}
