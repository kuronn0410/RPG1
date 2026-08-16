using UnityEngine;
using UnityEngine.UI;

public class SwitchWeaponButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField]  private Text nameTxt;
    [SerializeField] private Image weaponImage;
    public bool isSelected;

    private TownAudio audioPlayer;
    private WeaponType weaponType;
    private string weaponName;
    private Sprite weaponSprite;
    private WeaponHolder weaponHolder;
    private WeaponSwitchUI weaponSwitchUI;

    private void Awake()
    {
        audioPlayer = Object.FindAnyObjectByType<TownAudio>();

        if (audioPlayer == null)
        {
            Debug.LogError(
                $"{name}: TownAudioが設定されていません。",
                this
            );
        }
    }

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
        //button.image.sprite = weaponSprite;
        weaponImage.sprite = weaponSprite;

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
        button.image.color = Color.yellow;
        weaponImage.color = Color.white;
        nameTxt.text = "選択中";
    }

    public void ResetButton()
    {
        isSelected = false;
        button.interactable = true;
        button.image.color = Color.white;
        weaponImage.color = Color.white;
        nameTxt.text = weaponName;
    }

    public void SwitchWeapon()
    {
        
        bool result = weaponHolder.ChangeWeapon(weaponType);
      
        if (result)
        {
            weaponSwitchUI.ResetAllButtons();
            SelectState();
        }

        if (audioPlayer)
        {
            audioPlayer.Play(UISeType.WeaponChange);
        }
        else
        {
            Debug.LogError(
                $"{name}: TownAudioが設定されていません。",
                this
            );

        }
    }

}
