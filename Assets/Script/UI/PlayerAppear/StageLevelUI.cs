using UnityEngine;
using UnityEngine.UI;

public class StageLevelUI : MonoBehaviour
{
    [SerializeField] GameObject Level1;
    [SerializeField] GameObject Level2;
    [SerializeField] GameObject Level3;
    [SerializeField] Text LevelText;
   

    private Image level1Image;
    private Image level2Image;
    private Image level3Image;

    private void Awake()
    {
        level1Image = Level1.GetComponent<Image>();
        level2Image = Level2.GetComponent<Image>();
        level3Image = Level3.GetComponent<Image>();
    }

    void Start()
    {
        int level = PlayerLevelData.StageLevel;
        switch (level)
        {
            case 1:
                level1Image.color = Color.yellow;
                level2Image.color = Color.gray;
                level3Image.color = Color.gray;
                LevelText.text = "Level 1";
                break;
            case 2:
                level1Image.color = Color.yellow;
                level2Image.color = Color.yellow;
                level3Image.color = Color.gray;
                LevelText.text = "Level 2";
                break;
            case 3:
                level1Image.color = Color.yellow;
                level2Image.color = Color.yellow;
                level3Image.color = Color.yellow;
                LevelText.text = "Level 3";
                break;
            default:
                Debug.LogError("Invalid level: " + level);
                break;
        }
    }
}
