using UnityEngine;

public class OpenPanelUi : MonoBehaviour
{
    //ボタンを押したときに、パネルを表示するためのスクリプト
    [SerializeField] GameObject panel;
   
    void Start()
    {
        panel.SetActive(false); 
    }

    public void onClick()
    {
        panel.SetActive(!panel.activeSelf);

    }
}
