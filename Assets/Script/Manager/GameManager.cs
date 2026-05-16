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

    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
    }
    public bool IsPause() 
    {
        return isPause; 
    }

}
