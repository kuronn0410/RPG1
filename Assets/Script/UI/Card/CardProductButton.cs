using UnityEngine;
using UnityEngine.UI;


// カードのUIに付けるクラスボタン処理などをするクラス
// カードのUIを画像などをセットするクラス
// 使用箇所：CardProductButton
public class CardProductButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text nameTxt;
    [SerializeField] private Text costText;
    [SerializeField] private Image cardImage;
    [SerializeField] private GameObject rootObj;

    [SerializeField] private Sprite DebuffSprite;
    [SerializeField] private Sprite BuffSprite;
    [SerializeField] private Sprite HealSprite;
    [SerializeField] private Sprite AbilitySprite;

    private CardData cardData;
    private CardType cardType;
    private CardEffectType cardEffectType;
    private string name;
    private Sprite cardSprite;
    private int cost;
    private bool isSelected = false;
    private CardUIBase cardUIBase;

    public void SetUp(CardData cardData, CardButtonMode mode, CardUIBase cardUIBase)
    {
        this.cardUIBase = cardUIBase;

        this.cardType = cardData.cardType;
        this.cardEffectType = cardData.cardEffectType;
        this.name = cardData.cardName;
        this.nameTxt.text = name;
        this.cardSprite = cardData.cardSprite;
        this.cost = cardData.cost;
        this.costText.text = cost.ToString();
        cardImage.sprite = cardSprite;

        SetCardEffectType(cardEffectType);
       
        button.onClick.RemoveAllListeners();
        ButtonMode(mode);
        

    }


    private void ButtonMode(CardButtonMode mode)
    {
        switch (mode)
        {
            case CardButtonMode.PossessionCard:
                button.onClick.AddListener(() => OnPossessionCardClicked(cardType));
                //RefreshState();
                break;
            case CardButtonMode.Deck:
                button.onClick.AddListener(() => OnDeckCardClicked(cardType));
                break;
            case CardButtonMode.Use:
                // 使用モードの処理
                break;
        }
    }

    private void SetCardEffectType(CardEffectType cardEffectType)
    {
        switch (cardEffectType)
        {
            case CardEffectType.Debuff:
                button.image.sprite = DebuffSprite;
                break;
            case CardEffectType.Buff:
                button.image.sprite = BuffSprite;
                break;
            case CardEffectType.Heal:
                button.image.sprite = HealSprite;
                break;
            case CardEffectType.Ability:
                button.image.sprite = AbilitySprite;
                break;
        }
    }
    //このボタンのカードの種類を返す関数
    public CardType GetCardType()
    {
        return cardType;
    }

    /*
    public void RefreshState()
    {
        if (CardDeckManager.Instance.IsInDeck(cardType))
        {
            SelectState();
        }
        else
        {
            ResetButton();
        }
    }*/

    //カードがデッキに入っている状態の処理
    private void SelectState()
    {
        isSelected = true;
        button.interactable = false;
        button.image.color = Color.gray;
    }

    //カードがデッキに入っていない状態の処理
    public void ResetButton()
    {
        isSelected = false;
        button.interactable = true;
        button.image.color = Color.white;
    }

    public void OnPossessionCardClicked(CardType cardType)
    {
        CardDeckManager.Instance.AddCardToDeck(cardType);
        SelectState();  


    }

    //デッキからカードを外す処理
    //CardDeckManagerのRemoveCardFromDeckを呼び出して、カードをデッキから外す処理をする
    public void OnDeckCardClicked(CardType cardType)
    {
        CardDeckManager.Instance.RemoveCardFromDeck(cardType);
    }

    public void DestroyCardButton()
    {
        Destroy(rootObj);
    }
}
