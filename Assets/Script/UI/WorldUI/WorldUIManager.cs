
using UnityEngine;


/// <summary>
/// ワールドスペースのUIを管理・移動・表示するクラス
/// </summary>
public class WorldUIManager : MonoBehaviour
{
    //マップの移動
    [SerializeField] private GameObject SceneChangeButton;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private GameObject WeaponShopButton;
    [SerializeField] private GameObject WeaponShopParent;
    [SerializeField] private GameObject CardShopButton;
    [SerializeField] private GameObject CardShopParent;

    public bool IsWorldUIOpen = false;
    private void Awake()
    {
        Debug.Assert(SceneChangeButton != null, "WorldUIManager: SceneChangeButtonがアタッチされていません");
        Debug.Assert(parentObject != null, "WorldUIManager: parentObjectがアタッチされていません");
        //Debug.Assert(WeaponShopButton != null, "WorldUIManager: WeaponShopButtonがアタッチされていません");
        //Debug.Assert(WeaponShopParent != null, "WorldUIManager: WeaponShopParentがアタッチされていません");
        //Debug.Assert(CardShopButton != null, "WorldUIManager: CardShopButtonがアタッチされていません");
        //Debug.Assert(CardShopParent != null, "WorldUIManager: CardShopParentがアタッチされていません");
    }
    private void Start()
    {
        SceneChangeButton.SetActive(false);
        if (WeaponShopButton != null) { WeaponShopButton.SetActive(false); }
        if (CardShopButton != null) { CardShopButton.SetActive(false); }
    }

    public void ShowSceneChangeButton()
    {
        if(SceneChangeButton == null || parentObject == null) { return; }
        SceneChangeButton.transform.position = parentObject.transform.position;
        SceneChangeButton.transform.rotation = parentObject.transform.rotation;
        //text.text = sceneName;
        SceneChangeButton.SetActive(true);
        IsWorldUIOpen = true; 
    }

    public void HideSceneChangeButton()
    {
        SceneChangeButton.SetActive(false);
        IsWorldUIOpen = false;
    }


    public void ShowWeaponShopButton()
    {
        if(WeaponShopButton == null || WeaponShopParent == null) { return; }
        WeaponShopButton.transform.position = WeaponShopParent.transform.position;
        WeaponShopButton.transform.rotation = WeaponShopParent.transform.rotation;
        WeaponShopButton.SetActive(true);
        IsWorldUIOpen = true;
    }
    public void HideWeaponShopButton()
    {
        WeaponShopButton.SetActive(false);
        IsWorldUIOpen = false;
    }

    public void ShowCardShopButton()
    {
        if(CardShopButton!=null||CardShopParent==null) { return; }
        CardShopButton.transform.position = CardShopParent.transform.position;
        CardShopButton.transform.rotation = CardShopParent.transform.rotation;
        CardShopButton.SetActive(true);
        IsWorldUIOpen = true;
    }

    public void HideCardShopButton()
    {
        CardShopButton.SetActive(false);
        IsWorldUIOpen = false;
    }

}
