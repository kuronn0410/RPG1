using UnityEngine;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField] TitleButtonType titleButtonType;
    public void OnClick()
    {
        TitleUIManager.Instance.OnButtonClick(titleButtonType);
    }
}
