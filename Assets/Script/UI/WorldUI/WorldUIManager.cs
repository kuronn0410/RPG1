
using UnityEngine;


/// <summary>
/// ワールドスペースのUIを管理・移動・表示するクラス
/// </summary>
public class WorldUIManager : MonoBehaviour
{
    //マップの移動
    [SerializeField] private GameObject SceneChangeButton;
    [SerializeField] private GameObject parentObject;

    private void Awake()
    {
        Debug.Assert(SceneChangeButton != null, "WorldUIManager: SceneChangeButtonがアタッチされていません");
        Debug.Assert(parentObject != null, "WorldUIManager: parentObjectがアタッチされていません");
    }
    private void Start()
    {
        SceneChangeButton.SetActive(false);
    }

    public void ShowSceneChangeButton()
    {

        SceneChangeButton.transform.position = parentObject.transform.position;
        SceneChangeButton.transform.rotation = parentObject.transform.rotation;
        //text.text = sceneName;
        SceneChangeButton.SetActive(true);


    }

}
