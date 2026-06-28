using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using RPG.Save;
using System.Threading.Tasks;

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

    public async void OnButtonClick(TitleButtonType titleButtonType)
    {
        try
        { 
            switch (titleButtonType)
            {
                case TitleButtonType.Start:
                    await GameStart();
                    break;
                case TitleButtonType.Option:
                    Setting();
                    break;
                case TitleButtonType.Exit:
                    Exit();
                    break;
                case TitleButtonType.Restart:
                    await Restart();
                    break;
                case TitleButtonType.ToTitle:
                    ToTitle();
                    break;
                case TitleButtonType.Save:
                    await Save();
                    break;

            }
            return;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error occurred while handling button click: {ex.Message}");
        }
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

    private async Task GameStart()
    {
        if (continuGame == null) return;
        await continuGame.GameLoad();
        SceneMove.Instance.MoveToTown();

    }

        
    private void ToTitle()
    {
        SceneMove.Instance.MoveToTitle();
    }

    private async Task Restart()
    {
        if(resetGame == null)return;
        await resetGame.GameDataReset();
        SceneMove.Instance.MoveToTown();
    }

    private async Task Save()
    {
        Debug.Log("Save button clicked");
        if (saveSystem == null)return;
        await saveSystem.Save();
        // Implement save functionality here
    }
}
