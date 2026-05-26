using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    /*private void Awake()
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
    }*/

    public void Save()
    {
        Debug.Log("保存前");
        SaveData data = new SaveData();
        Debug.Log("データ形");
        SetSaveData(data);
        Debug.Log("セーブデータ設定完了");
        string json = JsonUtility.ToJson(data, true);//セーブデータをJSON形式に変換する処理
        string path = Application.persistentDataPath + "/save.json";//セーブデータを保存するパスを指定する処理
        File.WriteAllText(path, json);//セーブデータを保存する処理
        Debug.Log("ゲームを保存しました");

    }

    public void SetSaveData(SaveData data)
    {
        //それぞれのスクリプトからセーブデータを取得して、セーブデータに保存する処理
       data.playerLevel = PlayerLevelData.level;
       data.MaxHp = PlayerLevelData.maxHp;
       data.CurrentHp = PlayerLevelData.currentHp;
       data.Damage = PlayerLevelData.damage;
       data.CurrentExp = PlayerLevelData.nextLevelExperience;
       data.Money = PlayerLevelData.money;
       data.currentWeaponType = PlayerLevelData.currentWeaponType;
       data.possessionWeaponTypes = new List<WeaponType>(PossessionWeapon.possessionWeapon);
    }


}
