using UnityEngine;
/// <summary>
/// プレイヤーの変化レベルや経験値などのデータを管理するクラス
/// </summary>
public static class PlayerLevelData
{
    public static int level = 1;
    public static int currentHp = 90;
    public static int nextLevelExperience = 0;
    public static int money = 0;
    public static WeaponType currentWeaponType;
    public static int StageLevel = 1;

}