using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace RPG.Save
{
    /// <summary>
    /// 保存されているデータを取得して、セーブデータに保存する
    /// </summary>
    public class ContinuGame : MonoBehaviour
    {
        public void GameLoad()
        {
            //ゲームのデータをロードする処理
            string path1 = Application.persistentDataPath + "/save.json";
            if (!File.Exists(path1))
            {
                Debug.Log("セーブデータが見つかりませんでした");
                return;
            }
            string json1 = File.ReadAllText(path1);
            SaveData data1 = JsonUtility.FromJson<SaveData>(json1);
            ApplySaveData(data1);


            //ゲームの設定データをロードする処理
            string path2 = Application.persistentDataPath + "/settings.json";
            if (!File.Exists(path2))
            {
                Debug.Log("セーブデータが見つかりませんでした");
                return;
            }
            string json2 = File.ReadAllText(path2);
            SettingsData data2 = JsonUtility.FromJson<SettingsData>(json2);
            ApplaysettingSaveData(data2);

            return;


        }


        void ApplySaveData(SaveData data)
        {
            //Debug.Log("ContinuGame");
            PlayerLevelData.level = data.playerLevel;
            PlayerLevelData.currentHp = data.CurrentHp;
            PlayerLevelData.nextLevelExperience = data.CurrentExp;
            PlayerLevelData.money = data.Money;
            PlayerLevelData.currentWeaponType = data.currentWeaponType;
            PossessionWeapon.possessionWeapon = new HashSet<WeaponType>(data.possessionWeaponTypes);
            PlayerLevelData.StageLevel = data.StageLevel;
            CardDeckManager.setcards = new List<CardType>(data.setcards);
            PossessionCard.possessionCards = new HashSet<CardType>(data.possessionCards);
        }

        public void ApplaysettingSaveData(SettingsData data)
        {
            CurrentSettingDatas.mouseSensitivity = data.mouseSensitivity;
            CurrentSettingDatas.fps = data.fps;
        }
    }
}
