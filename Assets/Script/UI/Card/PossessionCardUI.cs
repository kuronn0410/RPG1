using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// 所持カードのUIの画像などを表示するクラス
//使用箇所：PossessionCardUI
public class PossessionCardUI : CardUIBase
{
    void Start()
    {
        foreach (var cardType in PossessionCard.possessionCards)
        {
            AddCardData(cardType);
        }
    }

    public void AddPossessionCardData(CardType cardType)
    {
        AddCardData(cardType);
    }
}
