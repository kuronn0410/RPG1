using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AudioSourceのループ再生を使わずに、SEを再生するためのクラス
/// </summary>
public class SEManager : MonoBehaviour
{

    //シーン内のIVolumeControllableを集めて、音量を一括で変更するためのクラス
    private readonly List<IVolumeControllable> volumeControllables = new();
    public static SEManager Instance;
    void Awake()
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
    

    public void Register(IVolumeControllable controllable)
    {
        if (controllable == null) return;

        if (!volumeControllables.Contains(controllable))
        {
            volumeControllables.Add(controllable);
        }
        controllable.SetVolume(SoundManager.Instance.GetSeVolume());
    }

    public void Unregister(IVolumeControllable controllable)
    {
        if (controllable == null) return;

        volumeControllables.Remove(controllable);
    }

    public void SetVolume(float volume)
    {
        foreach (var controllable in volumeControllables)
        {
            controllable.SetVolume(volume);
        }
    }
}
