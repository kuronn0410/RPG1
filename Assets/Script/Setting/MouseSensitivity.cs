using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マウス感度を管理するクラス
/// </summary>
public class MouseSensitivity : MonoBehaviour
{
    
    public static MouseSensitivity Instance;

    [SerializeField] private Slider sensitivitySlider;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 保存されてる値を取得するメソッド
    /// </summary>
    private void Start()
    {
        sensitivitySlider = GetComponent<Slider>();
        // 初期値を設定
        sensitivitySlider.value = SettingDatas.Sensitivity;
    }


    /// <summary>
    /// Sliderでマウス感度を設定するメソッド
    /// </summary>
    /// <param name="newSensitivity"></param>
    public void SetSensitivity(float newSensitivity)
    {
        SettingDatas.Sensitivity = newSensitivity;
    }

}
