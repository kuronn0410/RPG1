using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] EnemyDetection enemyDetection;
    [SerializeField] private Text hptext;
    [SerializeField] private GameObject correntHpbar;
    private RectTransform hpFill;
    private float maxWidth;
    private Image hpImage;

    private EnemyStatus currentEnemy;

    private void Awake()
    {
        //インスペクターで設定されていることを確認
        Debug.Assert(enemyDetection != null, "EnemyHPUI: enemyDetection が設定されていません");
        Debug.Assert(hptext != null);
        Debug.Assert(correntHpbar != null);
    }
    void Start()
    {
        hpFill = correntHpbar.GetComponent<RectTransform>();
        hpImage = correntHpbar.GetComponent<Image>();
        maxWidth = hpFill.sizeDelta.x;
    }

    /// <summary>
    /// 登録したイベントを
    /// オブジェクト破棄時に解除する
    /// </summary>
    private void OnEnable()
    {
        enemyDetection.OnClosestEnemyDetected += OnGetClosestEnemy;
    }


    private void OnDisable()
    {
        enemyDetection.OnClosestEnemyDetected -= OnGetClosestEnemy;

        if (currentEnemy != null)
        {
            currentEnemy.OnEnemyHpChanged -= UpdateHPUI;
        }
    }


    /// <summary>
    /// 近くの敵が変わった際に新しいEnemyStatusを取得してUIを更新する
    /// </summary>
    private void OnGetClosestEnemy(EnemyStatus enemy)
    {
        // 前の敵のHPイベントを解除
        if (currentEnemy != null)
        {
            currentEnemy.OnEnemyHpChanged -= UpdateHPUI;
        }

        currentEnemy = enemy;


        // 近くに敵がいない場合
        if (currentEnemy == null)
        {
            //HideHPUI();
            return;
        }

        // 新しい敵のHPイベントを購読
        currentEnemy.OnEnemyHpChanged += UpdateHPUI;

        // 初回表示
        UpdateHPUI(currentEnemy.remainHp, currentEnemy.SaveMaxHP);
    }




    void UpdateHPUI(int currentHp, int maxHp)
    {
        if (maxHp <= 0)
        {
            hptext.enabled = false;
            hpFill.sizeDelta = new Vector2(0, hpFill.sizeDelta.y);
        }
        else
        {
            hptext.enabled = true;

            hptext.text =
                currentHp +
                "/" +
                maxHp;

            float rate = (float)currentHp / maxHp;
            if (rate <= 0.3f)
            {
                hpImage.color = Color.red;
            }
            else if (rate <= 0.5f)
            {
                hpImage.color = Color.yellow;
            }
            else
            {
                hpImage.color = Color.green;
            }
            hpFill.sizeDelta = new Vector2(rate * maxWidth, hpFill.sizeDelta.y);
        }
    }
}
