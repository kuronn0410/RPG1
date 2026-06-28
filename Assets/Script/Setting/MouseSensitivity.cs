using RPG.Save;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マウス感度を管理するクラス
/// </summary>
public class MouseSensitivity : MonoBehaviour
{
    
    public static MouseSensitivity Instance;

    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private float waitTime = 1f;

    private Coroutine saveCoroutine;

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
        sensitivitySlider.value = CurrentSettingDatas.mouseSensitivity;
    }


    /// <summary>
    /// Sliderでマウス感度を設定するメソッド
    /// </summary>
    /// <param name="newSensitivity"></param>
    public void SetSensitivity(float newSensitivity)
    {
       CurrentSettingDatas.mouseSensitivity = newSensitivity;
        // 保存待機をリセット
        if (saveCoroutine != null)
        {
            StopCoroutine(saveCoroutine);
        }

        saveCoroutine = StartCoroutine(SaveDelay());
    }


    private IEnumerator SaveDelay()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        OnValueSave();
    }


    private async void OnValueSave()//async void入口で使う
    {
        try
        {
            await SettingSaveSystem.Instance.Save();

            Debug.Log(
                "マウス感度を保存しました: " +
                CurrentSettingDatas.mouseSensitivity);
        }
        catch (Exception e)
        {
            Debug.LogError("マウス感度の保存に失敗しました: " + e.Message);
        }
    }
}
