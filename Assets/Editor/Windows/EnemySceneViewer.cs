using RPG.Enemy;
using UnityEditor;
using UnityEngine;  

public class EnemySceneViewer : EditorWindow
{
    [MenuItem("Tools/CurrentEnemyDatabase")]
    public static void ShowWindow()
    {
        GetWindow<EnemySceneViewer>("CurrentEnemyDatabase");

    }
    private EnemyManager enemyManager;
    private void OnGUI()
    {
        GUILayout.Label("マップ上の敵のステータス", EditorStyles.boldLabel);

        
        if (GUILayout.Button("更新"))
        {
            enemyManager = FindAnyObjectByType<EnemyManager>();
        }

        if (enemyManager == null) return;
        foreach (EnemyStatus enemy in enemyManager.Enemies)
        {
            if (enemy == null)
                continue;
            GUILayout.Label(enemy.name);
            GUILayout.Label(enemy.remainHp.ToString());

        }
    }
}
