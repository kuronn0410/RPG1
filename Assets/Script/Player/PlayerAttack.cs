using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    [SerializeField] float IsAttackingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SwordAttack();
        }
       
    }

    private void SwordAttack()
    {
        IsAttacking = true;
        Debug.Log("çUåÇ");
        Invoke("ResetAttack", IsAttackingTime);
       
    }   

    private void ResetAttack()
    {
        IsAttacking = false;
    }
}
