using RPG.Save;
using UnityEngine;

public class SettingFPS : MonoBehaviour
{
    [SerializeField] FPSUIState fPSUIState;
    int currentFPS;
    void Start()
    {
        if(CurrentSettingDatas.fps == 30)
        {
            Fps30();
        }
        else if(CurrentSettingDatas.fps == 60)
        {
            Fps60();
        }
        else if (CurrentSettingDatas.fps == 120)
        {
            Fps120();
        }
    }


    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }

    public async void Fps30()
    {
        CurrentSettingDatas.fps = 30;
 
        SetFPS(CurrentSettingDatas.fps);
        fPSUIState.isFPS30 = true;
        fPSUIState.isFPS60 = false;
        fPSUIState.isFPS120 = false;
        fPSUIState.UpdateFPSUIState();
        //Debug.Log("FPSを30に設定しました。");
        await SettingSaveSystem.Instance.Save();
    }

    public async void Fps60()
    {
        CurrentSettingDatas.fps = 60;
        SetFPS(CurrentSettingDatas.fps);
        fPSUIState.isFPS30 = false;
        fPSUIState.isFPS60 = true;
        fPSUIState.isFPS120 = false;
        fPSUIState.UpdateFPSUIState();
        //Debug.Log("FPSを60に設定しました。");
        await SettingSaveSystem.Instance.Save();
    }

    public async void Fps120()
    {
        CurrentSettingDatas.fps = 120;
        SetFPS(CurrentSettingDatas.fps);
        fPSUIState.isFPS30 = false;
        fPSUIState.isFPS60 = false;
        fPSUIState.isFPS120 = true;
        fPSUIState.UpdateFPSUIState();
        //Debug.Log("FPSを120に設定しました。");
        await SettingSaveSystem.Instance.Save();
        
    }
}
