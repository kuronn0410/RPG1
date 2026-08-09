using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


/// <summary>
/// ワールドUIのボタンの動作を管理するクラス
/// </summary>
public class WorldButtonRun : MonoBehaviour
{
    //[SerializeField] string sceneName;

    public void SceneChange()
    {

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
}
