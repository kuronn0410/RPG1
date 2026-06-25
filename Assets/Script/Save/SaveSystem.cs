using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;//非同期処理を行うために必要な名前空間

namespace RPG.Save
{
    /// <summary>
    /// ゲームデータを取得して、セーブデータに保存する
    /// </summary>
    public class SaveSystem : MonoBehaviour
    {
        public static SaveSystem Instance;

        public async Task Save()
        {
            //Debug.Log("保存前");
            SaveData data = new SaveData();
            //Debug.Log("データ形");
            SetSaveData(data);
            //Debug.Log("セーブデータ設定完了");
            string json = JsonUtility.ToJson(data, true);//セーブデータをJSON形式に変換する処理
            string path = Application.persistentDataPath + "/save.json";//セーブデータを保存するパスを指定する処理
            await File.WriteAllTextAsync(path, json);//セーブデータを保存する処理
            Debug.Log("ゲームを保存しました");

        }

        public void SetSaveData(SaveData data)
        {
            //それぞれのスクリプトからセーブデータを取得して、セーブデータに保存する処理
            data.playerLevel = PlayerLevelData.level;
            data.CurrentHp = PlayerLevelData.currentHp;
            data.CurrentExp = PlayerLevelData.nextLevelExperience;
            data.Money = PlayerLevelData.money;
            data.currentWeaponType = PlayerLevelData.currentWeaponType;
            data.possessionWeaponTypes = new List<WeaponType>(PossessionWeapon.possessionWeapon);
            data.StageLevel = PlayerLevelData.StageLevel;
            data.setcards = new List<CardType>(CardDeckManager.setcards);
            data.possessionCards = new List<CardType>(PossessionCard.possessionCards);

        }


    }
}
