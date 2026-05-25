using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public int SaveLevel;
    public int SaveExperience = 0;
    [SerializeField] PlayerBaseStatus playerBaseStatus;
    private PlayerStatus playerStatus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerBaseStatus = GetComponent<PlayerBaseStatus>();
        playerStatus = GetComponent<PlayerStatus>();
        
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
        PlayerLevelData.maxHp += 1;
        PlayerLevelData.damage += 1;
        playerStatus.LevelUpHeal(); // レベルアップ時にHPを全回復
    }
}
