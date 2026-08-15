using System.Collections;
using UnityEngine;


// ボスのイントロパネルを表示するスクリプト
public class BossIntroUI : MonoBehaviour
{
    [SerializeField]
    private GameObject bossIntroPanel;

    [SerializeField]
    private float displayTime = 1f;

    private void Awake()
    {
        if (bossIntroPanel == null)
        {
            Debug.LogError(
                $"{nameof(BossIntroUI)}: BossIntroPanelが設定されていません。",
                this
            );
            enabled = false;
        }
    }

    private IEnumerator Start()
    {
       

        bossIntroPanel.SetActive(false);

        if (PlayerLevelData.StageLevel == 3)
        {
            yield return null; // Startメソッドの最初に1フレーム待機
            StartCoroutine(ShowBossIntro());
        }
    }

    private IEnumerator ShowBossIntro()
    {
        if (BgmManager.instance != null)
        {
            BgmManager.instance.BGMStopandPlay(
                BGMType.bossStage
            );
        }
        else
        {
            Debug.LogError(
                $"{nameof(BossIntroUI)}: BgmManagerが存在しません。",
                this
            );
        }



        bossIntroPanel.SetActive(true);
        GameManager.Instance.PauseGame();
        if(GameManager.Instance != null)
        {
            Debug.Log("ボスイントロ開始");
        }

        // timeScaleが0でも進む
        yield return new WaitForSecondsRealtime(displayTime);

        bossIntroPanel.SetActive(false);
        GameManager.Instance.ResumeGame();

        Debug.Log("ボスイントロ終了");
    }
}
