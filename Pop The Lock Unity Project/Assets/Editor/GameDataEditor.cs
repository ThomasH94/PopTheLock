using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        GUI.enabled = Application.isPlaying;

        GameData gameEvent = target as GameData;
        if (GUILayout.Button("Reset Data"))
        {
            gameEvent.ResetData();
        }
    }
}