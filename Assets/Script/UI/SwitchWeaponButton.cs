using UnityEngine;
using UnityEngine.UI;

public class SwitchWeaponButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField]  private Text nameTxt;
    public bool isSelected;
    
    private WeaponType weaponType;
    private string weaponName;
    private Sprite weaponSprite;
    private WeaponHolder weaponHolder;
    private WeaponSwitchUI weaponSwitchUI;

    public void SetUp(
        WeaponType weaponType, 
        string weaponName,
        Sprite weaponSprite, 
        WeaponHolder weaponHolder,
        WeaponSwitchUI weaponSwitchUI)
    {
        this.weaponType = weaponType; 
        this.weaponName = weaponName;
        this.weaponSprite = weaponSprite;
        this.weaponHolder = weaponHolder;
        this.weaponSwitchUI = weaponSwitchUI;
        nameTxt.text = weaponName;
        button.image.sprite = weaponSprite;
        

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            Debug.Log("BUTTON CLICK");
            SwitchWeapon();
        });
        ConfirmUsage();
    }

    private void ConfirmUsage()
    {
        if (weaponHolder.CheckCurrentWeapon(weaponType))
        {
            SelectState();
        }
    }

    private void SelectState()
    {
        isSelected = true;
        button.interactable = false;
        button.image.color = Color.gray;
    }

    public void ResetButton()
    {
        isSelected = false;
        button.interactable = true;
        button.image.color = Color.white;
    }

    public void SwitchWeapon()
    {
        
        bool result = weaponHolder.ChangeWeapon(weaponType);
        
        if (result)
        {
            weaponSwitchUI.ResetAllButtons();
            SelectState();
        }
    }

}
