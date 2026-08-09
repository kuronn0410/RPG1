using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Switch;
//using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    public static GuideManager Instance;
    public GuideData guideData;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            guideData = new GuideData();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private GuideType? currentGuideType;

   

    void Start()
    {
        
    }


    public bool CheckHasGuide(GuideType guideType)
    {
        switch (guideType)
        {
            case GuideType.operationGuide:
                return guideData.hasOperationGuide;
            case GuideType.battleRuleGuide:
                return guideData.hasBattleRuleGuide;
            case GuideType.shopGuide:
                return guideData.hasShopGuide;
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
            case GuideType.battleRuleGuide:
                guideData.hasBattleRuleGuide = true;
                break;
            case GuideType.shopGuide:
                guideData.hasShopGuide = true;
                break;
            default:
                break;
        }
        currentGuideType = guideType;
    }   
}
