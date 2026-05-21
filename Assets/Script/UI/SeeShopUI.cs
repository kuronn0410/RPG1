using UnityEngine;

public class SeeShopUI : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        Debug.Log("Shop Open");
        UIManager.Instance.ToggleShopPanel();
    }

}
