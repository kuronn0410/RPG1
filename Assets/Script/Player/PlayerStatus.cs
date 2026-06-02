using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerBaseStatus playerBaseStatus;

    public static PlayerStatus Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Header("PlayerStatus")]
    public int SaveMaxHP;//表示用
    //public int remainHp;
    private int baseDamage; // ダメージ量を保存する変数
    [Header("返す値")]
    public int dealingDamage;

    void Start()
    {
        LevelUpAndLoadData(PlayerLevelData.level);
    }


    public void LevelUpAndLoadData(int level)
    {
        SaveMaxHP = playerBaseStatus.baseHp+ (20*(level-1));
        baseDamage = playerBaseStatus.baseDamage + (5 *(level-1));
        //remainHp = PlayerLevelData.currentHp;
    }

    public void Damage(int takeDamage)
    {
        //Debug.Log("Take " + damage + " damage!");
        if (PlayerLevelData.currentHp > 0)
        {
            PlayerLevelData.currentHp -= takeDamage; // ダメージをHPから減算
            if (PlayerLevelData.currentHp <= 0)
            {
                PlayerLevelData.currentHp = 0;
                Debug.Log("Player defeated!");
                GameStateUI.Instance.GameOverPanel(); // ゲームオーバーUIを表示
            }
        }
    }

    public void LevelUpHeal()
    {
        PlayerLevelData.currentHp = SaveMaxHP;
    }

    //武器側に与えるダメージを計算するための関数
    public int DamageCalculation(int weapponDamage)
    {
        dealingDamage = baseDamage + weapponDamage; // 武器のダメージを保存
        return dealingDamage;
    }


    //カード使用時の処理
    public void Heal()
    {
        LevelUpHeal(); // HPを全回復
    }

    public void AttackUp(int attackAmount)
    {
        //１ターンの間、攻撃力を上昇させる処理
        baseDamage += attackAmount; // 攻撃力を上昇
        Debug.Log("Attack increased by " + attackAmount + "!");
    }

}
