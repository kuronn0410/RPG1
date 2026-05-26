using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject productButtonPrefab;
    [SerializeField] Transform parentObj;
    //[SerializeField] ShopType shopType;
    [SerializeField] ShopSystem shopSystem;
    [SerializeField] private ScriptableObject databaseObject;    
    private IShopDatabase shopDatabase;

    //[SerializeField] int between;
    
    private void Awake()
    {
        shopDatabase = databaseObject as IShopDatabase;
        //IShopDatabaseがついてるスクリプタブルオブジェクトを取得している
    }

    private int totalbetween =0;
    void Start()
    {

        foreach (var data in shopDatabase.GetAllItems())
        {
            CreateProductButton(shopSystem,data);
            
        }
    }


    public void CreateProductButton(ShopSystem shopSystem, IShop shopData)
    {
         GameObject button = Instantiate(productButtonPrefab, parentObj);
         button.GetComponent<ShopProductButton>().SetUp(shopSystem, shopData);
         //button.transform.localPosition = new Vector3(0, -totalbetween, 0);
         //totalbetween += between;
    }
}
