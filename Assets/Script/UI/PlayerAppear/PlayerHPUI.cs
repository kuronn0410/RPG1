using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    //[SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text playerHpText;
    [SerializeField] private Text playerLevelText;
    void Update()
    {
        if (PlayerStatus.Instance.SaveMaxHP <= 0)
        {
            playerHpText.enabled = false;
        }
        else
        {
            playerHpText.enabled = true;
            playerHpText.text = "HP: " + PlayerLevelData.currentHp + " / " + PlayerStatus.Instance.SaveMaxHP;
            playerLevelText.text = "Level: " + PlayerLevelData.level;
        }
       
    }
}
