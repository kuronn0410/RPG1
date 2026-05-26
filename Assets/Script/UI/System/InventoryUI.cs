using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.ToggleInventoryPanel();
            
        }
    }
}
