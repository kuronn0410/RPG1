using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerBaseStatus playerBaseStatus;

    [Header("Player HP")]
    public int SaveMaxHP;//表示用
    public int remainHp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveMaxHP = playerBaseStatus.baseHp;
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
                Debug.Log("Player defeated!");
            }
        }
    }
}
