using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ワールドUIのボタンのクリック
/// </summary>
    public class WorldUIButton : MonoBehaviour, IWorldUIHover
    {    
        [SerializeField] private WorldButtonRun worldButtonRun;
        [SerializeField] private WorldUIButtonType worldUIbuttonType;
    private Image buttonImage;

    private void Awake()
    {
        Debug.Assert(worldButtonRun != null, "WorldUIButton: WorldButtonRunがアタッチされていません");
        buttonImage = GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError("WorldUIButton: Imageコンポーネントが見つかりません");
        }
    }
    public void OnClick()
    {
        Debug.Log("ボタンがクリックされました");
        switch (worldUIbuttonType)
        {
            case WorldUIButtonType.SceneChange:
                worldButtonRun.SceneChange();
                break;
            default:
                Debug.LogError("WorldUIButton: 未定義のボタンタイプ");
                break;
        }
    }

    public void OnHoverEnter()
    { 
        Debug.Log("ボタンにマウスオーバー");
        buttonImage.color = Color.gray; // ボタンがクリックされたときの色を変更
    }

    public void OnHoverExit()
    {
        buttonImage.color = Color.white; // ボタンから離れたときの色を元に戻す
    }
}
