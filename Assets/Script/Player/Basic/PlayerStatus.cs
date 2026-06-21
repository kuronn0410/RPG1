using UnityEngine;
using System;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerBaseStatus playerBaseStatus;

    public static PlayerStatus Instance;

    [Header("PlayerStatus")]
    public int SaveMaxHP;//表示用
    //public int remainHp;
    private int baseDamage; // ダメージ量を保存する変数
    [Header("返す値")]
    public int dealingDamage;
    [Header("一ステージ分の値保存")]
    private int maxHpUp = 0;

    public event Action<int, int> OnHpChanged;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LevelUpAndLoadData(PlayerLevelData.level);
        OnHpChanged?.Invoke(PlayerLevelData.currentHp, SaveMaxHP); // HPの初期値を通知
    }

    public void LevelUpAndLoadData(int level)
    {
        SaveMaxHP = playerBaseStatus.baseHp + (20 * (level - 1));
        if (maxHpUp > 0)
        {
            SaveMaxHP += maxHpUp;
        }
        baseDamage = playerBaseStatus.baseDamage + (5 * (level - 1));
        //remainHp = PlayerLevelData.currentHp;
    }

    public void Damage(int takeDamage)
    {
        //Debug.Log("Take " + damage + " damage!");
        if (PlayerLevelData.currentHp > 0)
        {
            PlayerLevelData.currentHp -= takeDamage; // ダメージをHPから減算
            OnHpChanged?.Invoke(PlayerLevelData.currentHp, SaveMaxHP);
            if (PlayerLevelData.currentHp <= 0)
            {
                PlayerLevelData.currentHp = 0;
                Debug.Log("Player defeated!");
                OnHpChanged?.Invoke(PlayerLevelData.currentHp, SaveMaxHP);
                GameStateUI.Instance.GameOverPanel(); // ゲームオーバーUIを表示

            }
        }
    }
    //HP関連の関数
    public void Heal()
    {
        LevelUpHeal(); // HPを全回復
    }
    public void LevelUpHeal()
    {
        PlayerLevelData.currentHp = SaveMaxHP;
        OnHpChanged?.Invoke(PlayerLevelData.currentHp, SaveMaxHP);
    }

    public void MaxHpUp(int maxHpUpAmount)
    {
        SaveMaxHP += maxHpUpAmount; // 最大HPを上昇
        maxHpUp += maxHpUpAmount; // 一ステージ分の最大HP上昇量を保存
        //PlayerLevelData.currentHp = SaveMaxHP; // 現在のHPも最大HPに合わせて回復
        OnHpChanged?.Invoke(PlayerLevelData.currentHp, SaveMaxHP);
        Debug.Log("Max HP increased by " + maxHpUpAmount + "!");
    }


    //武器側に与えるダメージを計算するための関数
    public int DamageCalculation(int weapponDamage)
    {
        dealingDamage = baseDamage + weapponDamage; // 武器のダメージを保存
        return dealingDamage;
    }
    public void AttackUp(int attackAmount)
    {
        //１ターンの間、攻撃力を上昇させる処理
        baseDamage += attackAmount; // 攻撃力を上昇
        Debug.Log("Attack increased by " + attackAmount + "!");
    }


}
