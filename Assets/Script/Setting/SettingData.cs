using UnityEngine;

/// <summary>
/// 設定の初期値
/// </summary>
[CreateAssetMenu(fileName = "SettingData", menuName = "Data/SettingData")]
public class SettingData : ScriptableObject
{
  public float BGMVolume = 1.0f; // BGMの音量の初期値
  public float MouseSensitivity = 1.0f;// マウス感度の初期値
  public int  Fps = 60; // フレームレートの初期値
}
