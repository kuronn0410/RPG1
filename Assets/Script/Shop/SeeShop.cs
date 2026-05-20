using UnityEngine;

public class SeeShop : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject shopPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopPanel.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("Shop Open");
        shopPanel.SetActive(true);
        Debug.Log(shopPanel.activeSelf);
    }

}
