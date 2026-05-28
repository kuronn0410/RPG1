using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "CardShopDatabase",menuName = "CardShopDatabase")]
public class CardShopDatabase : ScriptableObject, IShopDatabase
{
    [SerializeField] List<CardShopData> cardShopDataList;
    public List<IShop> GetAllItems()
    {
        return cardShopDataList.Cast<IShop>().ToList();
    }

}
