using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    private EnemyMove1 enemyMove;
    void Start()
    {
        enemyMove = GetComponent<EnemyMove1>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run", enemyMove.IsMoving);
    }
}
