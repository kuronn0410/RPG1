using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public static SceneMove Instance;

    public void Awake()
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

    public void MoveToMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void MoveToTown()
    {
        SceneManager.LoadScene("Town");
    }

    public void MoveToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
