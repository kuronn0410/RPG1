using UnityEngine;

public class LoadUIManager : MonoBehaviour
{
    [SerializeField] GameObject loadPanel;
    public static LoadUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        loadPanel.SetActive(false);
    }

    public void ShowLoadPanel()
    {
        if (loadPanel == null) return;
        if (!loadPanel.activeSelf)
        {
            loadPanel.SetActive(true);
        }
    }

    public void HideLoadPanel()
    {
        if (loadPanel == null) return;
        if(loadPanel.activeSelf)
        {
            loadPanel.SetActive(false);
        }
       
    }
}
