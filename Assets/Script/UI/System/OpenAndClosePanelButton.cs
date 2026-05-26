using UnityEngine;

public class OpenAndClosePanelButton : MonoBehaviour
{
    //ボタンを押したときに、パネルを表示するためのスクリプト
   [SerializeField] private UIPanelType panelType;

    public void onClick()
    {
        switch (panelType)
        {
            case UIPanelType.WeaponShop:
                UIManager.Instance.ToggleWeaponShopPanel();
                break;
            case UIPanelType.CardShop:
                UIManager.Instance.ToggleCardShopPanel();
                break;
            case UIPanelType.Inventory:
                UIManager.Instance.ToggleInventoryPanel();
                break;
            case UIPanelType.WeaponChange:
                UIManager.Instance.ToggleWeaponChangePanel();
                break;
            case UIPanelType.Pause:
                UIManager.Instance.TogglePausePanel();
                break;
        }
    }
}
