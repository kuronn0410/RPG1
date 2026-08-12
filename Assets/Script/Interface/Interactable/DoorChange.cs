using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorChange : MonoBehaviour, IWorldUIDisplayable
{
    [SerializeField] WorldUIManager worldUIManager;

    public string GetInteractionText()
    {
        return "クリック:ドアを開ける";
    }

    //public void Interact()
    //{
    //    if (!enabled) return;
    //    //worldUIManager.ShowSceneChangeButton();
    //    return;
    //}

    public void ShowWorldUI()
    {
        if (!enabled) return;
        worldUIManager.ShowSceneChangeButton();
    }

    public void HideWorldUI()
    {
        if (!enabled) return;
        worldUIManager.HideSceneChangeButton();
    }   

}
