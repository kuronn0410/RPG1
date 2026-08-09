using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneMove : MonoBehaviour
{
    public static SceneMove Instance;

    public void Awake()
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

    public async Task MoveToMap()
    {
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Map");
        LoadUIManager.Instance.HideLoadPanel();
        BgmChange(BGMType.battle);
        Debug.Log("SceneMove: MoveToMap");
    }

    public async Task MoveToTown()
    {
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Town");
        LoadUIManager.Instance.HideLoadPanel();
        BgmChange(BGMType.town);
    }
   
    public async Task MoveToTitle()
    {
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Title");
        LoadUIManager.Instance.HideLoadPanel();
        BgmChange(BGMType.title);
    }

    public void BgmChange(BGMType bgmType)
    {
        BgmManager.instance.BGMStopandPlay(bgmType);
    }

}
