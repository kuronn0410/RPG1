using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class TownGuideUIController : MonoBehaviour
{

    [SerializeField] GameObject operationGuidePanel;
    [SerializeField] GameObject shopGuidePanel;
    private GuideManager guideManager;


    void Awake()
    {
        Debug.Assert(operationGuidePanel!=null, "Operation Guide Panel is not assigned in the inspector.");
    }
    private IEnumerator Start()
    {
        guideManager = Object.FindAnyObjectByType<GuideManager>();
        if (guideManager == null)
        {
            Debug.LogError("GuideManager not found in the scene.");

        }
        yield return null;
        DisplayGuide(GuideType.operationGuide);
        Debug.Log("OperationGuideUIController initialized.");
        DisplayGuide(GuideType.shopGuide);
        Debug.Log("TownGuideUIController initialized.");
    }


    public void DisplayGuide(GuideType guideType)
    {
       switch(guideType)
       {
           case GuideType.operationGuide:
                Debug.Log("Displaying operation guide.");
                if (!guideManager.CheckHasGuide(guideType)
                    && operationGuidePanel != null)
                {
                    operationGuidePanel.SetActive(true);
                    guideManager.UsedGuidePanel(guideType);
                }
                break;
            case GuideType.shopGuide:

                Debug.Log("shopGuide hasGuide = " + guideManager.CheckHasGuide(guideType));
                Debug.Log("shopGuide panel = " + shopGuidePanel);
                Debug.Log("previous is battle = " + SceneMove.Instance.CheckPreviousScene(SceneType.battle));

                if (!guideManager.CheckHasGuide(guideType)
                    && shopGuidePanel != null
                    &&SceneMove.Instance.CheckPreviousScene(SceneType.battle))
                {
                    shopGuidePanel.SetActive(true);
                    GameManager.Instance.PauseGame();
                    guideManager.UsedGuidePanel(guideType);
                }
                break;
            

        }
    }


    public void OnClickCloseShopGuidePanel()
    {
        if (shopGuidePanel != null && shopGuidePanel.activeSelf)
        {
            shopGuidePanel.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
    }
}
