using System;
using UnityEngine;
using UnityEngine.UI;
/*音量を管理する*/
public class SoundManager : MonoBehaviour
{
    [SerializeField] private BgmManager bgmManager;
    //[SerializeField] private SfxManager sfxManager;

    [SerializeField] private float masterVolume = 1f;
    [SerializeField] private float bgmVolume = 0.5f;
    [SerializeField] private float sfxVolume = 1f;

    [SerializeField] private Slider bgmVolumeSlider;
    

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
    }

    public void MasterVolume(float volume)
    {

        //masterVolume = Mathf.Clamp01(volume);
        // マスターボリュームを更新する処理をここに追加
    }   

    public void BgmVolume(float volume)
    {
        bgmVolumeSlider.value = volume;
        bgmManager.SetVolume(volume);
        //bgmVolume = Mathf.Clamp01(volume);
        // BGMの音量を更新する処理をここに追加
    }


    //public void SfxVolume(float volume)
    //{
    //    sfxVolume = Mathf.Clamp01(volume);
    //    // SFXの音量を更新する処理をここに追加
    //}
}
