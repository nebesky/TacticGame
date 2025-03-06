using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGeneratorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var levelGenerator = (LevelGenerator)target;

        if (GUILayout.Button("Generate Level JSON"))
            levelGenerator.OnGenerateLevelButtonClick();
    }
}