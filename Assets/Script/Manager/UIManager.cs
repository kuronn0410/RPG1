using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    [SerializeField] GameObject shopPanel;
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
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        weaponChangePanel.SetActive(false);
        pausePanel.SetActive(false);
        OpenPanelCount=0;
        GameManager.Instance.ResumeGame();
    }


    public void ToggleShopPanel()
    {
        ToggleUI(shopPanel);
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
}
