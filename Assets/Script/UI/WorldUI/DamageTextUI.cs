using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Player;

/// <summary>
/// 敵のダメージイベントを受け取る
///ダメージ値を表示する
///一定時間後に非表示にする
/// </summary>
public class DamageTextUI : MonoBehaviour
{
    
    [SerializeField] private DamageDisplay damageDisplay1;
    [SerializeField] private DamageDisplay damageDisplay2;
    [SerializeField] private DamageDisplay damageDisplay3;

    [SerializeField] private float deleteTime = 10f;
    

    [SerializeField] EnemyDetection enemyDetection;
    private EnemyStatus currentEnemy;
    private EnemyDamagePos currentEnemyDamagePos;

    //表示中のダメージテキスト
    private readonly Queue<DamageDisplay> availableDisplays = new();
    private void Awake()
    {
        Debug.Assert(damageDisplay1 != null, "DamageTextUI: damageDisplay1がアタッチされていません");
        Debug.Assert(damageDisplay2 != null, "DamageTextUI: damageDisplay2がアタッチされていません");
        Debug.Assert(damageDisplay3 != null, "DamageTextUI: damageDisplay3がアタッチされていません");
        Debug.Assert(enemyDetection != null, "DamageTextUI: enemyDetectionがアタッチされていません");
    }

    private void Start()
    {
        AddDisplay(damageDisplay1);
        AddDisplay(damageDisplay2);
        AddDisplay(damageDisplay3);
    }

    private void AddDisplay(DamageDisplay display)
    {
        display.panel.SetActive(false);
        availableDisplays.Enqueue(display);
    }

    private void OnEnable()
    {
        enemyDetection.OnClosestEnemyDetected += OnGetClosestEnemy; // 敵がダメージを受けたときに呼ばれるイベントに登録する
    }
    private void OnDisable()
    {
        enemyDetection.OnClosestEnemyDetected -= OnGetClosestEnemy; // イベント登録を解除する
        if (currentEnemy != null)
        {
            currentEnemy.OnEnemyDamage -= DamageDisplaying;
            currentEnemy = null;
        }
    }

    /// <summary>
    /// 敵がダメージを受けたときに呼ばれるイベントに登録する
    /// </summary>
    /// <param name="enemy"></param>
    private void OnGetClosestEnemy(EnemyStatus enemy)
    {
        if (currentEnemy != null)
        {
            currentEnemy.OnEnemyDamage -= DamageDisplaying; // 前の敵のイベント登録を解除する
        }

        currentEnemy = enemy;

        if (currentEnemy == null)
        {
            return;
        }

        currentEnemy.OnEnemyDamage += DamageDisplaying;
    }

    /// <summary>
    /// 表示中のダメージを管理する
    /// </summary>
    private void DamageDisplaying(int damage)
    {
        if (availableDisplays.Count > 0)
        {
            // 先頭から表示中のダメージテキストを取得する
            DamageDisplay display = availableDisplays.Dequeue();
            // 使用中だった場合は、停止する
            if (display.hideCoroutine != null)
            {
                StopCoroutine(display.hideCoroutine);
            }
           
            ShowDamageText(damage, display);
            // 使用後はキューに戻す
            availableDisplays.Enqueue(display);

        }
    }

    /// <summary>
    /// ダメージ値のパネルを表示する
    /// </summary>
    /// <param name="damage"></param>
    public void ShowDamageText(int damage, DamageDisplay damageDisplay)
    {
        // ダメージ値を敵の近くに移動する
        DamageDisplayToNear(damageDisplay);
        // ダメージ値を表示する
        damageDisplay.panel.SetActive(true);
        SetDamageText(damage, damageDisplay);
        // 新しい非表示処理を開始して保存
        damageDisplay.hideCoroutine = StartCoroutine(HideAfterTime(damageDisplay));
    }
    private IEnumerator HideAfterTime(DamageDisplay display)
    {
        yield return new WaitForSeconds(deleteTime);
        display.panel.SetActive(false);
        display.hideCoroutine = null;

    }
    /// <summary>
    /// ダメージ値を表示する
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="damageDisplay"></param>
    public void SetDamageText(int damage, DamageDisplay damageDisplay)
    {
        damageDisplay.text.text = damage.ToString();
    }


    /// <summary>
    /// 敵のダメージを近くに表示する
    /// </summary>
    /// <param name="position"></param>
    /// <param name="damage"></param>
    public void DamageDisplayToNear(DamageDisplay damageDisplay)
    {
        currentEnemyDamagePos = currentEnemy.GetComponent<EnemyDamagePos>();
        if (currentEnemyDamagePos == null)
        {
            return;
        }
        else
        {
            damageDisplay.panel.transform.position = currentEnemyDamagePos.damagePos1.position;
            damageDisplay.panel.transform.rotation = currentEnemyDamagePos.damagePos1.rotation;
        }
    }
}
