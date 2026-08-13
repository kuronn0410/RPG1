using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.ProjectAuditor.Editor.Core;


/// <summary>
/// ワールドUIのボタンの動作を管理するクラス
/// </summary>
public class WorldButtonRun : MonoBehaviour
{
    [SerializeField] GameObject AudioScript;
    IUISePlayer AudioPlayer;

    void Start()
    {
        AudioPlayer = AudioScript.GetComponent<IUISePlayer>();
    }

    public void SceneChange()
    {
        AudioPlayer.Play(UISeType.SceneMove);
        string currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "Map")
        {
            SceneMove.Instance.MoveToTown();
        }
        else if(currentSceneName == "Town")
        {
            SceneMove.Instance.MoveToMap();
        }
        Debug.Log("シーン変更");
        //if (sceneName != null)
        //{
        //    SceneManager.LoadScene(sceneName);

        //}
       
    }

    public void SeeShopUI(WorldUIButtonType worldUIbuttonType)
    {
        Debug.Log("Shop Open");
        switch (worldUIbuttonType)
        {
            case WorldUIButtonType.WeaponShopUI:
                AudioPlayer.Play(UISeType.MenuSelect);
                UIManager.Instance.ToggleWeaponShopPanel();
                break;
            case WorldUIButtonType.CardShopUI:
                AudioPlayer.Play(UISeType.MenuSelect);
                UIManager.Instance.ToggleCardShopPanel();
                break;
        }
    }
}

