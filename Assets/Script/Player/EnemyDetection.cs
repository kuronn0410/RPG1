using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
    private EnemyStatus closestEnemy;
    public int SaveHP;
    public int SaveMaxHP;

    void Update()
    {
        DetectEnemy();
    }

    private void DetectEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionDistance);
        float closestDistance = detectionDistance;
        SaveHP = 0;
        SaveMaxHP = 0;
        closestEnemy = null;


        foreach (Collider hitCollider in hitColliders)
        {
            EnemyStatus enemy = hitCollider.GetComponent<EnemyStatus>();
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                    SaveHP = closestEnemy.remainHp;
                    SaveMaxHP = closestEnemy.SaveMaxHP;
                }
                    
            }
        }
        
    }
}