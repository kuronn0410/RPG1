using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Switch;
//using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    public static GuideManager Instance;
    //[SerializeField] private GameObject optionGuidePanel;
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
    private GuideType? currentGuideType;

    public GuideData guideData;

    void Start()
    {
        guideData = new GuideData();
    }


    public bool CheckHasGuide(GuideType guideType)
    {
        switch (guideType)
        {
            case GuideType.operationGuide:
                return guideData.hasOperationGuide;
            case GuideType.bottleRuleGuide:
                return guideData.hasBottleRuleGuide;
            default:
                return false;
        }
    }

    public void UsedGuidePanel(GuideType guideType)
    {
        switch (guideType)
        {
            case GuideType.operationGuide:
                guideData.hasOperationGuide = true;
                break;
            case GuideType.bottleRuleGuide:
                guideData.hasBottleRuleGuide = true;
                break;
            default:
                break;
        }
        currentGuideType = guideType;
    }   
}
