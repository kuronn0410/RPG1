using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    
    public event System.Action<int> OnMoneyChanged;
    public void AddMoney(int amount)
    {
        PlayerLevelData.money += amount;
        OnMoneyChanged?.Invoke(PlayerLevelData.money);
    }

    public void DecreaseMoney(int amount)
    {
        PlayerLevelData.money -= amount;
        if (PlayerLevelData.money < 0)
        {
            PlayerLevelData.money = 0; // お金がマイナスにならないようにする
        }
        OnMoneyChanged?.Invoke(PlayerLevelData.money);
    }
}
