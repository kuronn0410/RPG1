using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveData 
{
    public int playerLevel;
    public int MaxHp;
    public int CurrentHp;
    public int Damage;
    public int CurrentExp;
    public int Money;
    public WeaponType currentWeaponType;
    public List<WeaponType> possessionWeaponTypes;
}
