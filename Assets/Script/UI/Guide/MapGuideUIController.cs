using UnityEngine;
using System.Collections;
public class MapGuideUIController : MonoBehaviour
{
    [SerializeField] GameObject bottleRuleGuidePanel;
    private GuideManager guideManager;
    //private GameManager gameManager;

    void Awake()
    {
        Debug.Assert(bottleRuleGuidePanel != null, "Bottle Rule Guide Panel is not assigned in the inspector.");
    }
    private IEnumerator Start()
    {
        guideManager = Object.FindAnyObjectByType<GuideManager>();
        yield return null;
        DisplayGuide(GuideType.bottleRuleGuide);
        Debug.Log("MapGuideUIController initialized.");
    }


    public void DisplayGuide(GuideType guideType)
    {
        switch (guideType)
        {
            case GuideType.bottleRuleGuide:
                Debug.Log("Displaying bottle rule guide.");
                if (!guideManager.CheckHasGuide(guideType)
                    && bottleRuleGuidePanel != null)
                {
                    
                    bottleRuleGuidePanel.SetActive(true);
                    GameManager.Instance.PauseGame();
                    Debug.Log("Bottle rule guide displayed and game paused.. timeScale = " + Time.timeScale);
                    guideManager.UsedGuidePanel(guideType);

                }
                break;

        }
    }


    //ボタンに登録する用
    public void OnClickCloseBottleRuleGuidePanel()
    {
        if (bottleRuleGuidePanel != null && bottleRuleGuidePanel.activeSelf)
        {
            bottleRuleGuidePanel.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
    }
}
