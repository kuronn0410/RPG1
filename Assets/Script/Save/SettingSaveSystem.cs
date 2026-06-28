using UnityEngine;
using System.IO;
using System.Threading.Tasks;

namespace RPG.Save
{
    public class SettingSaveSystem : MonoBehaviour
    {
        public static SettingSaveSystem Instance;
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

        public async Task Save()
        {
            SettingsData data = new SettingsData();
            //Debug.Log("SettingsDataを保存します。");
            SetSettingsData(data);
            //Debug.Log("SettingsDataを保存しました。");
            string json = JsonUtility.ToJson(data, true);
            //Debug.Log("SettingsDataをJSONに変換しました。");
            string path = Application.persistentDataPath + "/settings.json";
            await File.WriteAllTextAsync(path, json);
            //Debug.Log("設定を保存しました");
        }

        private void SetSettingsData(SettingsData data)
        {
            //data.bgmVolume = AudioManager.Instance.bgmVolume;
            data.mouseSensitivity = CurrentSettingDatas.mouseSensitivity;
            data.fps = CurrentSettingDatas.fps;
        }

    }
}

