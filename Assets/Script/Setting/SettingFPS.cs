using RPG.Save;
using UnityEngine;
using System.Threading.Tasks;

public class SettingFPS : MonoBehaviour
{
    [SerializeField] FPSUIState fPSUIState;
    private void Start()
    {
        ApplyFPS(CurrentSettingDatas.fps, false);
    }

    public async Task Fps30()
    {
        await ApplyFPS(30, true);
    }

    public void Fps60()
    {
        ApplyFPS(60, true);
    }

    public void Fps120()
    {
        ApplyFPS(120, true);
    }

    private async Task ApplyFPS(int fps, bool save)
    {
        CurrentSettingDatas.fps = fps;
        SetFPS(fps);

        fPSUIState.isFPS30 = fps == 30;
        fPSUIState.isFPS60 = fps == 60;
        fPSUIState.isFPS120 = fps == 120;
        fPSUIState.UpdateFPSUIState();

        if (save)
        {
            await SettingSaveSystem.Instance.Save();
        }
    }

    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
