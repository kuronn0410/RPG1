using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


/// <summary>
/// ワールドUIのボタンの動作を管理するクラス
/// </summary>
public class WorldButtonRun : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void SceneChange()
    {
        Debug.Log("シーン変更");
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);

        }
    }
}
