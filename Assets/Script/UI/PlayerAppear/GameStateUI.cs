using UnityEngine;

public class GameStateUI : MonoBehaviour
{

    public static GameStateUI Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    void Start()
    {
        if(gameOverPanel)
        {
            gameOverPanel.SetActive(false);
        }
        if(victoryPanel)
        {
            victoryPanel.SetActive(false);
        }
    }

    public void OpenUI(GameObject uiPanel)
    {
        if (!uiPanel.activeSelf)
        {
            uiPanel.SetActive(true);
            GameManager.Instance.PauseGame();
        }

    }

    public void GameOverPanel()
    {
        OpenUI(gameOverPanel);
    }
    public void VictoryPanel()
    {
        OpenUI(victoryPanel);
    }
}
