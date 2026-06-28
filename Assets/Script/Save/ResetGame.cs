using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Save
{
    /// <summary>
    /// ゲームデータを初期状態で上書きする　セーブデータがなくならないよう消去しない
    /// </summary>
    public class ResetGame : MonoBehaviour
    {
        [SerializeField] private ContinuGame continuGame;
        [SerializeField] private PlayerBaseStatus playerBaseStatus;

        public async Task GameDataReset()
        {
            //Debug.Log("ゲームデータをリセットしました");
            await CreateNewGame();
            Debug.Log("新しいゲームデータを作成しました");
            await continuGame.GameLoad();
        }

        public async Task CreateNewGame()
        {

            SaveData data = new SaveData();
            SetInitializeGameData(data);
            string json = JsonUtility.ToJson(data, true);
            string path = Application.persistentDataPath + "/save.json";
            await File.WriteAllTextAsync(path, json);

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