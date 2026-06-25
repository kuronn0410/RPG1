using UnityEngine;
using System.Collections.Generic;

namespace RPG.Save
{
    /// <summary>
    /// セーブするもののデータをまとめたクラス
    /// </summary>
    [System.Serializable]
    public class SaveData
    {
        public int playerLevel;
        public int CurrentHp;
        public int CurrentExp;
        public int Money;
        public WeaponType currentWeaponType;
        public List<WeaponType> possessionWeaponTypes;
        public int StageLevel;
        public List<CardType> setcards;
        public List<CardType> possessionCards;

    }
}