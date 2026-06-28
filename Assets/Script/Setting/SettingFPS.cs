using RPG.Save;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class SettingFPS : MonoBehaviour
{
    [SerializeField] FPSUIState fPSUIState;
    
    private void Start()
    {
       ApplyFPS(CurrentSettingDatas.fps);
    }
    /// <summary>
    /// FPSを設定するメソッド async void を入口にして使う
    /// </summary>
    public async void Fps30()
    {
        await ChangeFPS(30);
    }

    public async void Fps60()
    {
        await ChangeFPS(60);
    }

    public async void Fps120()
    {
        await ChangeFPS(120);
    }

    private async Task ChangeFPS(int fps)
    {
        try
        {
            ApplyFPS(fps);
            await SettingSaveSystem.Instance.Save();
            Debug.Log($"FPSを{fps}に設定しました");
        }
        catch (Exception e)
        {
            Debug.LogError("FPS設定の保存に失敗しました: " + e.Message);
        }
    }

    private void  ApplyFPS(int fps)
    {
        CurrentSettingDatas.fps = fps;
        SetFPS(fps);
        fPSUIState.UpdateFPSUIState(fps);
    }

    /// <summary>
    /// FPSを実際に設定するメソッド
    /// </summary>
    /// <param name="fps"></param>
    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
