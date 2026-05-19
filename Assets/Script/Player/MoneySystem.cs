using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public void AddMoney(int amount)
    {
        PlayerLevelData.money += amount;
    }
}
