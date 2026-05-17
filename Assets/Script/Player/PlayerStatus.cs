using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerBaseStatus playerBaseStatus;

    [Header("Player HP")]
    private int SaveHP;//表示用
    private int remainHp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveHP = playerBaseStatus.baseHp;
        remainHp = playerBaseStatus.baseHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        Debug.Log("Take " + damage + " damage!");
        // Here you can implement health reduction, death, etc.
        if (remainHp > 0)
        {
            remainHp -= damage; // ダメージをHPから減算
            if (remainHp <= 0)
            {
                remainHp = 0;
                // プレイヤーが死亡した場合の処理をここに追加
                Debug.Log("Player defeated!");
                // 例えば、ゲームオーバー画面を表示するなどの処理を行うことができます。
            }
        }
    }
}
