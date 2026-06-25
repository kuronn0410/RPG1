using UnityEngine;

public class SettingFPS : MonoBehaviour
{
    [SerializeField] FPSUIState fPSUIState;
    void Start()
    {
        // 初期設定として60FPSに設定
        Fps60();
    }


    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }

    public void Fps30()
    {
        SetFPS(30);
        fPSUIState.isFPS30 = true;
        fPSUIState.isFPS60 = false;
        fPSUIState.isFPS120 = false;
        fPSUIState.UpdateFPSUIState();
    }

    public void Fps60()
    {
        SetFPS(60);
        fPSUIState.isFPS30 = false;
        fPSUIState.isFPS60 = true;
        fPSUIState.isFPS120 = false;
        fPSUIState.UpdateFPSUIState();
    }

    public void Fps120()
    {
        SetFPS(120);
        fPSUIState.isFPS30 = false;
        fPSUIState.isFPS60 = false;
        fPSUIState.isFPS120 = true;
        fPSUIState.UpdateFPSUIState();
    }
}
