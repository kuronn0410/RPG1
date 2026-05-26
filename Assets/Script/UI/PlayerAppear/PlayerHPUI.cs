using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    //[SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text playerHpText;
    [SerializeField] private Text playerLevelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerStatus = FindFirstObjectByType<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLevelData.maxHp <= 0)
        {
            playerHpText.enabled = false;
        }
        else
        {
            playerHpText.enabled = true;
            playerHpText.text = "HP: " + PlayerLevelData.currentHp + " / " + PlayerLevelData.maxHp;
            playerLevelText.text = "Level: " + PlayerLevelData.level;
        }
       
    }
}
