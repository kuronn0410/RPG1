using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneMove : MonoBehaviour
{
    public static SceneMove Instance;
    private SceneType currentSceneType;
    private SceneType previousSceneType;

    public void Awake()
    {
        
    
        if (Instance == null)
        {
          
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentSceneType = SceneType.title;
            previousSceneType = SceneType.title;
        }
        else
        {
            Destroy(gameObject);
        }
    }


   

    /// <summary>
    /// 前のシーンが指定されたシーンタイプと同じかどうかを確認する
    /// </summary>
    /// <param name="sceneType">確認したい前のシーンタイプ</param>
    /// <returns></returns>
    public bool CheckPreviousScene(SceneType sceneType)
    {
        if (previousSceneType == sceneType)
        {
            return true;
        }
        return false;
    }


    public async Task MoveToMap()
    {
        previousSceneType = currentSceneType;
        currentSceneType = SceneType.battle;
        Debug.Log($"MoveToMap: previous={previousSceneType}, current={currentSceneType}");
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Map");
        LoadUIManager.Instance.HideLoadPanel();
        BgmChange(BGMType.battle);
        Debug.Log("SceneMove: MoveToMap");
    }

    public async Task MoveToTown()
    {
        previousSceneType = currentSceneType;
        currentSceneType = SceneType.town;
        Debug.Log($"MoveToTown: previous={previousSceneType}, current={currentSceneType}");
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Town");
        LoadUIManager.Instance.HideLoadPanel();
        BgmChange(BGMType.town);
       
    }
   
    public async Task MoveToTitle()
    {
        previousSceneType = currentSceneType;
        currentSceneType = SceneType.title;
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
