using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    [SerializeField] GameObject WeaponShopPanel;
    [SerializeField] GameObject CardShopPanel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject weaponChangePanel;
    [SerializeField] GameObject pausePanel;

    private int OpenPanelCount = 0;

    //[SerializeField] private GameObject ;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   void Start()
    {
        CloseAllUI();
    }

    public void ToggleUI(GameObject uiPanel)
    {
        if(uiPanel.activeSelf)
        {
            CloseUI(uiPanel);
        }
        else
        {
            OpenUI(uiPanel);
        }
    }

    public void OpenUI(GameObject uiPanel)
    {
        if(!uiPanel.activeSelf)
        {
            uiPanel.SetActive(true);
            OpenPanelCount++;
            GameManager.Instance.PauseGame();
        }
        
    }

    public void CloseUI(GameObject uiPanel)
    {
        if(uiPanel.activeSelf)
        {
            uiPanel.SetActive(false);
            OpenPanelCount--;
            if (OpenPanelCount <= 0)
            {
                GameManager.Instance.ResumeGame();
            }
        }
        
    }

    public void CloseAllUI()
    {
        if(WeaponShopPanel)
            WeaponShopPanel.SetActive(false);
        if(CardShopPanel)
            CardShopPanel.SetActive(false);
        if (inventoryPanel)
            inventoryPanel.SetActive(false);
        if(weaponChangePanel)
            weaponChangePanel.SetActive(false);
        if(pausePanel)
            pausePanel.SetActive(false);
        OpenPanelCount=0;

        GameManager.Instance.ResumeGame();
    }


    public void ToggleWeaponShopPanel()
    {
        ToggleUI(WeaponShopPanel);
    }
    public void ToggleInventoryPanel()
    {
        ToggleUI(inventoryPanel);
    }
    public void ToggleWeaponChangePanel()
    {
        ToggleUI(weaponChangePanel);
    }
    public void TogglePausePanel()
    {
        ToggleUI(pausePanel);
    }
    public void ToggleCardShopPanel()
    {
        ToggleUI(CardShopPanel);
    }

}
