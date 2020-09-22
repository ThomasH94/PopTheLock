using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        GUI.enabled = Application.isPlaying;

        GameEvent gameEvent = target as GameEvent;
        if (GUILayout.Button("Raise"))
        {
            gameEvent.Raise();
        }
    }
}