using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private MoneySystem moneySystem;
    
    private void Awake()
    {
        //インスペクターで設定されていることを確認
        Debug.Assert(moneyText != null, "MoneyUI: moneyText が設定されていません");
        Debug.Assert(moneySystem != null, "MoneyUI: moneySystem が設定されていません");
    }

    public void Start()
    {
        
        
        //MoneySystemのイベントに登録
        moneySystem.OnMoneyChanged += MoneyUpdate;
        //初期表示
        MoneyUpdate(PlayerLevelData.money);
    }

    private void OnDestroy()
    {
        //MoneySystemのイベントから登録解除
        if (moneySystem != null)
        {
            moneySystem.OnMoneyChanged -= MoneyUpdate;
        }
    }

    private void MoneyUpdate(int newMoney)
    {
        moneyText.text = "Money: " + newMoney;
    }
}
