using UnityEngine;
using System.Collections.Generic;

public class WeaponSwitchUI : MonoBehaviour
{
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private int HorizontalInterval;
    [SerializeField] private int VerticalInterval;
    [SerializeField] private GameObject parentObj;
    [SerializeField] private GameObject productButtonPrefab;
    [SerializeField] private WeaponDatabase weaponDatabase;

    private List<SwitchWeaponButton> buttons
        = new List<SwitchWeaponButton>();


    public int totalHorizontalInterval = 0;
    public int totalVerticalInterval = 0;
    public int totalProductCount = 0;


    void Start()
    {
        foreach( var weaponType in PossessionWeapon.possessionWeapon)
        {
            var weaponData = weaponDatabase.GetWeaponData(weaponType);
            
            string name = weaponData.weaponName;
            Sprite sprite = weaponData.weaponSprite;
            CreateWeaponButton(weaponType, name, sprite);
        }
    }

    public void GetPossessionWeapon(WeaponType weaponType)
    {

       var weaponData = weaponDatabase.GetWeaponData(weaponType);
       string name = weaponData.weaponName;
       Sprite sprite = weaponData.weaponSprite;
       CreateWeaponButton(weaponType, name, sprite);
    }



    public void CreateWeaponButton(WeaponType weaponType, string name, Sprite sprite)
    {
        totalProductCount++;
        GameObject buttonObj = Instantiate(productButtonPrefab, parentObj.transform);
        buttonObj.GetComponent<SwitchWeaponButton>().
            SetUp(weaponType,
                name,
                sprite,
                weaponHolder,
                this);
        
        buttons.Add(buttonObj.GetComponent<SwitchWeaponButton>());

        buttonObj.transform.localPosition = new Vector3(totalHorizontalInterval, -totalVerticalInterval, 0);
        totalHorizontalInterval += HorizontalInterval;


        if (totalProductCount % 4 == 0)
        {
           totalHorizontalInterval = 0;
           totalVerticalInterval += VerticalInterval;
        }
            
    }

    public void ResetAllButtons()
    {
        foreach (var button in buttons)
        {
            button.ResetButton();
        }
    }


}
