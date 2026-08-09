using UnityEngine;
using System.Collections;
public class MapGuideUIController : MonoBehaviour
{
    [SerializeField] GameObject battleRuleGuidePanel;
    private GuideManager guideManager;
    //private GameManager gameManager;

    void Awake()
    {
        Debug.Assert(battleRuleGuidePanel != null, "Battle Rule Guide Panel is not assigned in the inspector.");
    }
    private IEnumerator Start()
    {
        guideManager = Object.FindAnyObjectByType<GuideManager>();
        yield return null;
        DisplayGuide(GuideType.battleRuleGuide);
        Debug.Log("MapGuideUIController initialized.");
    }


    public void DisplayGuide(GuideType guideType)
    {
        switch (guideType)
        {
            case GuideType.battleRuleGuide:
                Debug.Log("Displaying battle rule guide.");
                if (!guideManager.CheckHasGuide(guideType)
                    && battleRuleGuidePanel != null)
                {
                    
                    battleRuleGuidePanel.SetActive(true);
                    GameManager.Instance.PauseGame();
                    Debug.Log("Battle rule guide displayed and game paused.. timeScale = " + Time.timeScale);
                    guideManager.UsedGuidePanel(guideType);

                }
                break;

        }
    }


    //ボタンに登録する用
    public void OnClickCloseBattleRuleGuidePanel()
    {
        if (battleRuleGuidePanel != null && battleRuleGuidePanel.activeSelf)
        {
            battleRuleGuidePanel.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
    }
}
