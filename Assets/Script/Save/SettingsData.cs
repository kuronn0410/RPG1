using UnityEngine;
namespace RPG.Save
{
    /// <summary>
    /// 保存する設定データを保持するクラス
    /// </summary>
    [System.Serializable]
    public class SettingsData 
    {
       public float bgmVolume;
       public float mouseSensitivity;
       public int fps;
    }
}
