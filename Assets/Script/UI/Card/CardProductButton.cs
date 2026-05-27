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

    public void SetUp(CardData cardData)
    {

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
        button.onClick.AddListener(() => OnCardButtonClicked(cardType));

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

    public void OnCardButtonClicked(CardType cardType)
    {
        Debug.Log(cardType + "カードボタンがクリックされました");
    }
}
