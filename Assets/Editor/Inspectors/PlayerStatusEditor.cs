using UnityEditor;
using UnityEngine;
using RPG.Player;

[CustomEditor(typeof(PlayerStatus))]
public class PlayerStatusEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Label("PlayerStatus ä«óù", EditorStyles.boldLabel);

        // å≥ÇÃInspectorÇï\é¶
        DrawDefaultInspector();

        GUILayout.Space(10);

        PlayerStatus playerStatus = (PlayerStatus)target;

        if (GUILayout.Button("HPëSâÒïú"))
        {
            playerStatus.LevelUpHeal();
            EditorUtility.SetDirty(playerStatus);
        }

        if (GUILayout.Button("ç≈ëÂHP +10"))
        {
            playerStatus.MaxHpUp(10);
            EditorUtility.SetDirty(playerStatus);
        }
        if (GUILayout.Button("ç≈ëÂHP -10"))
        {
            playerStatus.MaxHpUp(-10);
            EditorUtility.SetDirty(playerStatus);
        }

        if (GUILayout.Button("çUåÇóÕ +5"))
        {
            playerStatus.AttackUp(5);
            EditorUtility.SetDirty(playerStatus);
        }
       
    }
}