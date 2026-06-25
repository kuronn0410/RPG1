using UnityEngine;
using System.IO;
using System.Collections.Generic;
namespace RPG.Save
{
    /// <summary>
    /// ゲームデータを消去して、初期状態を上書きする
    /// </summary>
    public class ResetGame : MonoBehaviour
    {
        [SerializeField] private ContinuGame continuGame;
        [SerializeField] private PlayerBaseStatus playerBaseStatus;

        public void GameDataReset()
        {
            //Debug.Log("ゲームデータをリセットしました");
            DeleteSaveData();
            Debug.Log("セーブデータを削除しました");
            CreateNewGame();
            Debug.Log("新しいゲームデータを作成しました");
            continuGame.GameLoad();

        }

        public void DeleteSaveData()
        {
            string path = Application.persistentDataPath + "/save.json";
            if (!File.Exists(path))
            {
                // Debug.Log("セーブデータが見つかりませんでした");
                return;
            }
            else
            {
                File.Delete(path);
                //Debug.Log("セーブデータ削除");
            }
        }



        public void CreateNewGame()
        {

            SaveData data = new SaveData();
            SetInitializeGameData(data);
            string json = JsonUtility.ToJson(data, true);
            string path = Application.persistentDataPath + "/save.json";
            File.WriteAllText(path, json);

            //Debug.Log("新しいゲームを開始します");

            return;
        }

        void SetInitializeGameData(SaveData data)
        {
            data.playerLevel = playerBaseStatus.playerLevel;
            data.CurrentHp = playerBaseStatus.baseHp;
            data.currentWeaponType = WeaponType.Sword;
            data.CurrentExp = 0;
            data.Money = 0;
            data.possessionWeaponTypes = new List<WeaponType>() { WeaponType.Sword };
            data.StageLevel = 1;
            data.setcards = new List<CardType>();
            data.possessionCards = new List<CardType>();
            Debug.Log("ResetGame");
        }
    }
}