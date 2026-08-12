using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
/*音量を管理する*/
public class SoundManager : MonoBehaviour
{
    [SerializeField] private BgmManager bgmManager;
    [SerializeField] private SEManager seManager;
    //[SerializeField] private SfxManager sfxManager;

    // 音量の初期値を設定する
    [SerializeField] private float masterVolume = 1f;
    [SerializeField] private float bgmVolume = 0.5f;
    [SerializeField] private float seVolume = 0.5f;

    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider seVolumeSlider;

    public static SoundManager Instance;
    private void Awake()
    {
        // シングルトンの初期化処理
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        // 初期化処理
        bgmVolumeSlider.value = bgmVolume;
        BgmVolume(bgmVolume);
        seVolumeSlider.value = seVolume;
        SeVolume(seVolume);
    }

    public void MasterVolume(float volume)
    {

        //masterVolume = Mathf.Clamp01(volume);
        // マスターボリュームを更新する処理をここに追加
    }   

    public void BgmVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        if (bgmVolumeSlider)
        {
            bgmVolumeSlider.value = volume;
        }
        bgmManager.SetVolume(volume);
        //bgmVolume = Mathf.Clamp01(volume);
        // BGMの音量を更新する処理をここに追加
    }


    public void SeVolume(float volume)
    {
        seVolume = Mathf.Clamp01(volume);
        if (seVolumeSlider)
        {
            seVolumeSlider.value = seVolume;
        }
        seManager.SetVolume(volume);
        // SEの音量を更新する処理をここに追加
    }


    public float GetMasterVolume()
    {
        return masterVolume;
    }

    public float GetBgmVolume()
    {
        return bgmVolume;
    }

    public float GetSeVolume()
    {
        return seVolume;
    }
}
