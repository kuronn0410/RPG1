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
    void Update()
    {
        if (enemyDetection.SaveMaxHP <= 0)
        {
            hptext.enabled = false;
            hpFill.sizeDelta = new Vector2(0, hpFill.sizeDelta.y);
        }
        else
        {
            hptext.enabled = true;

            hptext.text =
                enemyDetection.SaveHP +
                "/" +
                enemyDetection.SaveMaxHP;

            float rate = (float)enemyDetection.SaveHP / enemyDetection.SaveMaxHP;
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
