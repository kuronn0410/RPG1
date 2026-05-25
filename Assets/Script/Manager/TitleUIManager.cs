using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{

    [SerializeField] private ResetGame resetGame;
    [SerializeField] private ContinuGame continuGame;
    [SerializeField] private SaveSystem saveSystem;

    [SerializeField] private GameObject settingPanel;
    public static TitleUIManager Instance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (settingPanel == null) return;
        settingPanel.SetActive(false);
    }

    public void OnButtonClick(TitleButtonType titleButtonType)
    {
        switch (titleButtonType)
        {
            case TitleButtonType.Start:
                GameStart();
                break;
            case TitleButtonType.Option:
                Setting();
                break;
            case TitleButtonType.Exit:
                Exit();
                break;
            case TitleButtonType.Restart:
                Restart();
                break;
            case TitleButtonType.ToTitle:
                ToTitle();
                break;
            case TitleButtonType.Save:
                Save();
                break;

        }
        return;
    }

   
    private void Setting()
    {
        if (settingPanel == null)return;
        settingPanel.SetActive(true);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void GameStart()
    {
        if (continuGame == null) return;
        continuGame.GameLoad();
        SceneMove.Instance.MoveToTown();

    }

        
    private void ToTitle()
    {
        SceneMove.Instance.MoveToTitle();
    }

    private void Restart()
    {
        if(resetGame == null)return;
        resetGame.GameDataReset();
        SceneMove.Instance.MoveToTown();
    }

    private void Save()
    {
        Debug.Log("Save button clicked");
        if (saveSystem == null)return;
        saveSystem.Save();
        // Implement save functionality here
    }
}
