using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// 所持カードのUIの画像などを表示するクラス
//使用箇所：PossessionCardUI
public class PossessionCardUI : MonoBehaviour
{

    [SerializeField] private int HorizontalInterval;
    [SerializeField] private int VerticalInterval;
    [SerializeField] private GameObject parentObj;
    [SerializeField] private GameObject productButtonPrefab;
    [SerializeField] private CardDatabase cardDatabase;

    private int totalHorizontalInterval = 0;
    private int totalVerticalInterval = 0;
    //private int totalProductCount = 0;
    private int totalCardCount = 0;
    private List<CardProductButton> buttons = new List<CardProductButton>();

    void Start()
    {
        foreach (var cardType in PossessionCard.possessionCards)
        {
            var cardData = cardDatabase.GetCardData(cardType);
            if (cardData == null)
            {
                Debug.LogError($"{cardType} の CardData が見つかりません");
                continue;
            }
            CreateCardButton(cardData);
        }
    }

    private void CreateCardButton(CardData cardData)
    {
        totalCardCount++;
        GameObject buttonObj = Instantiate(productButtonPrefab, parentObj.transform);
        buttonObj.GetComponentInChildren<CardProductButton>().SetUp(cardData);
        buttons.Add(buttonObj.GetComponent<CardProductButton>());
        buttonObj.transform.localPosition = new Vector3(totalHorizontalInterval, -totalVerticalInterval, 0);
        totalHorizontalInterval += HorizontalInterval;


        if (totalCardCount % 4 == 0)
        {
            totalHorizontalInterval = 0;
            totalVerticalInterval += VerticalInterval;
        }
    }

    public void ResetAllButtons()
    {
        foreach (var button in buttons)
        {
            //button.ResetButton();
            Debug.Log("カードのリセット");
        }
    }


}
