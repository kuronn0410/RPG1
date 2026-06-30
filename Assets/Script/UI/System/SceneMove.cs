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
    }

    public async Task MoveToTown()
    {
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Town");
        LoadUIManager.Instance.HideLoadPanel();
    }
   
    public async Task MoveToTitle()
    {
        LoadUIManager.Instance.ShowLoadPanel();
        await SceneManager.LoadSceneAsync("Title");
        LoadUIManager.Instance.HideLoadPanel();
    }
}
