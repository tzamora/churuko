using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SaveOnRun
{
    static SaveOnRun()
    {
        EditorApplication.playmodeStateChanged += SaveCurrentScene;
    }

    static void SaveCurrentScene()
    {
        if (!EditorApplication.isPlaying
            && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            EditorApplication.SaveScene();
        }
    }
}