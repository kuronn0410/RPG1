using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ContinuGame : MonoBehaviour
{
    public void GameLoad()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (!File.Exists(path))
        {
           Debug.Log("セーブデータが見つかりませんでした");
            return;
        }
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        ApplySaveData(data);
        Debug.Log("ゲームを続きから開始します");
        return;
    }
    void ApplySaveData(SaveData data)
    {
        Debug.Log("ContinuGame");
        PlayerLevelData.level = data.playerLevel;
        PlayerLevelData.maxHp = data.MaxHp;
        PlayerLevelData.currentHp = data.CurrentHp;
        PlayerLevelData.damage = data.Damage;
        PlayerLevelData.nextLevelExperience = data.CurrentExp;
        PlayerLevelData.money = data.Money;
        PlayerLevelData.currentWeaponType = data.currentWeaponType;
        PossessionWeapon.possessionWeapon = new HashSet<WeaponType>(data.possessionWeaponTypes);
    }
}
