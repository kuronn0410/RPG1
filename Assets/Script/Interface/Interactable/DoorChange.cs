using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorChange : MonoBehaviour, IInteractable
{
    [SerializeField] string sceneName; // Raycast‚Ì‹——£
   

    public void Interact()
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
