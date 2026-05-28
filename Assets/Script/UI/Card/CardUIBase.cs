using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class CardUIBase : MonoBehaviour
{
    [SerializeField] protected int HorizontalInterval;
    [SerializeField] protected int VerticalInterval;
    [SerializeField] protected GameObject parentObj;
    [SerializeField] protected GameObject productButtonPrefab;
    [SerializeField] protected CardDatabase cardDatabase;
    [SerializeField] protected CardButtonMode mode;
    protected int totalHorizontalInterval = 0;
    protected int totalVerticalInterval = 0;
    //private int totalProductCount = 0;
    protected int totalCardCount = 0;
    
    protected List<CardProductButton> buttons = new List<CardProductButton>();
    

    protected virtual void AddCardData(CardType cardType)
    {
        var cardData = cardDatabase.GetCardData(cardType);
        if (cardData == null)
        {
            Debug.LogError($"{cardType} ‚Ì CardData ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
            return;
        }
        CreateCardButton(cardData,mode,this);
    }


    protected virtual void CreateCardButton(CardData cardData, CardButtonMode mode, CardUIBase cardUIBase)
    {
        totalCardCount++;
        GameObject buttonObj = Instantiate(productButtonPrefab, parentObj.transform);

        buttonObj.GetComponentInChildren<CardProductButton>().SetUp(cardData, mode, cardUIBase);
        buttons.Add(buttonObj.GetComponentInChildren<CardProductButton>());

        buttonObj.transform.localPosition = new Vector3(totalHorizontalInterval, -totalVerticalInterval, 0);
        totalHorizontalInterval += HorizontalInterval;


        if (totalCardCount % 5 == 0)
        {
            totalHorizontalInterval = 0;
            totalVerticalInterval += VerticalInterval;
        }
    }


    public void ResetAllButtons()
    {
        foreach (var button in buttons)
        {
            button.RefreshState();
        }
    }

    public void RemoveButton(CardProductButton button)
    {
        buttons.Remove(button);
        totalCardCount--;
        totalHorizontalInterval -= HorizontalInterval;
    }
}
