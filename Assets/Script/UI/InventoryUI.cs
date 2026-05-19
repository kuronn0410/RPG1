using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        inventoryPanel.SetActive(false); // Ensure the inventory panel is hidden at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(!inventoryPanel.activeSelf)
            {
                OpenInventory();
                gameManager.PauseGame();
            }
            else 
            {
                 CloseInventory();
                gameManager.ResumeGame();
            }

        }
        
    }

    void OpenInventory()
    {
        inventoryPanel.SetActive(true); // Show the inventory panel
    }

    void CloseInventory()
    {
        inventoryPanel.SetActive(false); // Hide the inventory panel
    }
}
