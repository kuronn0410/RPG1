using UnityEngine;
using System.IO;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private ContinuGame continuGame;

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
       data.playerLevel = 1;
       data.MaxHp = 100;
       data.CurrentHp = 100;
       data.CurrentExp = 0;
       data.Damage = 5;
       data.currentWeaponType = WeaponType.Sword;
       data.Money = 0;
        Debug.Log("ResetGame");
    }
}
