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

    [SerializeField] private TitleAudio titleAudio;
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
                    titleAudio.PlayGameStartSE();
                    await GameStart();
                    break;
                case TitleButtonType.Option:
                    titleAudio.PlayMenuSelectSE();
                    Setting();
                    break;
                case TitleButtonType.Exit:
                    //titleAudio.PlayExitSE();
                    Exit();
                    break;
                case TitleButtonType.Restart:
                    //titleAudio.PlayDefaultSE();
                    await Restart();
                    break;
                case TitleButtonType.ToTitle:
                    //titleAudio.PlayDefaultSE();
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
        if(!settingPanel.activeSelf)
        {
            settingPanel.SetActive(true);
        }
        else
        {
            settingPanel.SetActive(false);
        }
    }

    private void Exit()
    {
        Application.Quit();
    }

    private async Task GameStart()
    {
        if (continuGame == null) return;
        await continuGame.GameLoad();
    }

    

    private async void ToTitle()
    {
       await SceneMove.Instance.MoveToTitle();
    }

    private async Task Restart()
    {
        if(resetGame == null)return;
        await resetGame.GameDataReset();
    }

    private async Task Save()
    {
        Debug.Log("Save button clicked");
        if (saveSystem == null)return;
        await saveSystem.Save();
        // Implement save functionality here
    }
}
