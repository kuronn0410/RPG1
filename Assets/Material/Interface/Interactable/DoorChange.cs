using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorChange : MonoBehaviour, IInteractable
{
    [SerializeField] WorldUIManager worldUIManager;


    public void Interact()
    {
        if(!enabled) return;
        worldUIManager.ShowSceneChangeButton();

    }
}
