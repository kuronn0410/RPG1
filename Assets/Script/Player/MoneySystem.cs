using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public void AddMoney(int amount)
    {
        PlayerLevelData.money += amount;
    }

    public void DecreaseMoney(int amount)
    {
        PlayerLevelData.money -= amount;
    }
}
