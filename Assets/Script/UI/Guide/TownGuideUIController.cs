using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TownGuideUIController : MonoBehaviour
{

    [SerializeField] GameObject operationGuidePanel;
    private GuideManager guideManager;


    void Awake()
    {
        Debug.Assert(operationGuidePanel!=null, "Operation Guide Panel is not assigned in the inspector.");
    }
    void Start()
    {
        guideManager = Object.FindAnyObjectByType<GuideManager>();
        DisplayGuide(GuideType.operationGuide);
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
           
       }
    }
    
}
