using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("Tools/My Tool")]
    public static void ShowWindow()
    {
        GetWindow<MyEditorWindow>("My Tool");

    }
    private void OnGUI()
    {
        GUILayout.Label("エディタ拡張の練習", EditorStyles.boldLabel);

        if (GUILayout.Button("押す"))
        {
            Debug.Log("ボタンが押されました");
        }
    }
}
