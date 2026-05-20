using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isPause = false;
    void Awake()
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

    public static void SetCursorState(bool isCursor)
    {
        if (isCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
        SetCursorState(true);
    }

    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        SetCursorState(false);
    }
    public bool IsPause() 
    {
        return isPause; 
    }

    

}
