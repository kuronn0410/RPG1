using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ワールドスペースのUIを管理・移動・表示するクラス
/// </summary>
public class WorldUIManager : MonoBehaviour
{
    [SerializeField] private GameObject SceneChangeButton;
    [SerializeField] private GameObject parentObject;
    //[SerializeField] private Text text;

    private void Awake()
    {
        Debug.Assert(SceneChangeButton != null, "WorldUIManager: SceneChangeButtonがアタッチされていません");
        Debug.Assert(parentObject != null, "WorldUIManager: parentObjectがアタッチされていません");
        //Debug.Assert(text != null, "WorldUIManager: textがアタッチされていません");
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
