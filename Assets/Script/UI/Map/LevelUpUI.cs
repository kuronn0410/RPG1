using UnityEngine;
using System.Collections;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;

    
    void Awake()
    {
        Debug.Assert(levelUpPanel != null, "Level Up Panel is not assigned in the inspector.");
    }

    void Start()
    {
        levelUpPanel.SetActive(false);
    }
    public void openLevelUpPanel()
    {
        levelUpPanel.SetActive(true);
        StartCoroutine(closeLevelUpPanel());
    }

    private IEnumerator closeLevelUpPanel()
    {
        yield return new WaitForSeconds(3f);
        levelUpPanel.SetActive(false);
    }

}
