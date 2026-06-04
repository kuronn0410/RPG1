using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    //[SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text playerHpText;
    [SerializeField] private Text playerLevelText;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private ExperienceSystem experienceSystem;


    private void Awake()
    {
        //インスペクターで設定されていることを確認
        Debug.Assert(playerStatus != null, "PlayerHPUI: playerStatus が設定されていません");
        Debug.Assert(experienceSystem != null, "PlayerHPUI: experienceSystem が設定されていません");
        Debug.Assert(playerHpText != null);
        Debug.Assert(playerLevelText != null);
    }

    private void Start()
    {
        playerStatus.OnHpChanged += UpdateHpText;
        UpdateHpText(PlayerLevelData.currentHp, playerStatus.SaveMaxHP);

        experienceSystem.OnLevelUp += UpdateLevelText;
        UpdateLevelText(PlayerLevelData.level);

    }

    private void OnDestroy()
    {
        if (playerStatus != null)
        {
            playerStatus.OnHpChanged -= UpdateHpText;
        }
        if (experienceSystem != null)
        {
            experienceSystem.OnLevelUp -= UpdateLevelText;
        }
    }

    private void UpdateHpText(int currentHp, int maxHp)
    {
        if (maxHp <= 0)
        {
            playerHpText.enabled = false;
        }
        else
        {
            playerHpText.enabled = true;
            playerHpText.text = "HP: " + currentHp + " / " + maxHp;
        }
       
    }

    private void UpdateLevelText(int level)
    {
        playerLevelText.text = "Level: " + level;
    }
}
