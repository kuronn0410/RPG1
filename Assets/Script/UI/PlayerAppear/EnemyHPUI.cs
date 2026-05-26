using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] EnemyDetection enemyDetection;
    [SerializeField] private Text hptext;
    void Start()
    {
        enemyDetection = FindObjectOfType<EnemyDetection>();
    }
    void Update()
    {
        if (enemyDetection.SaveMaxHP <= 0)
        {
            hptext.enabled = false;
        }
        else
        {
            hptext.enabled = true;

            hptext.text =
                enemyDetection.SaveHP +
                "/" +
                enemyDetection.SaveMaxHP;
        }
    }
}
