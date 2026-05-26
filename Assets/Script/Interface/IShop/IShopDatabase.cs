using UnityEngine;
using System.Collections.Generic;


public interface IShopDatabase
{
    List<IShop> GetAllItems();
}
