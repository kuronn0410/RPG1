using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text playerHpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStatus = FindFirstObjectByType<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatus.SaveMaxHP <= 0)
        {
            playerHpText.enabled = false;
        }
        else
        {
            playerHpText.enabled = true;
            playerHpText.text = "HP: " + playerStatus.remainHp + " / " + playerStatus.SaveMaxHP;
        }
       
    }
}
