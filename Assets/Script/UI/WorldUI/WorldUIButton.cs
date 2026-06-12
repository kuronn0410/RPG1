using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ワールドUIのボタンのクリック
/// </summary>
public class WorldUIButton : MonoBehaviour
{
    [SerializeField] private WorldButtonRun worldButtonRun;
    [SerializeField] private WorldUIButtonType  orldUIbuttonType;
    
    public void OnClick()
    {
        switch (orldUIbuttonType)
        {
            case WorldUIButtonType.SceneChange:
                worldButtonRun.SceneChange();
                break;
            default:
                Debug.LogError("WorldUIButton: 未定義のボタンタイプ");
                break;
        }
    }
}
