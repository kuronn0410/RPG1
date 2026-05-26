using UnityEngine;

public interface IShop 
{
    Sprite Sprite { get; }
    string Name { get; }
    int Price { get; }

    void Purchase();
    bool IsOwned();
}
