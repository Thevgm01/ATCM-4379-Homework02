using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IterationScript))]
public class EditorIterationScript : Editor
{
    Transform obj;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        IterationScript cube = (IterationScript)target;

        GUILayout.Space(20);

        GUILayout.Label("Iteration");
        GUILayout.BeginHorizontal();
            if(GUILayout.Button("Iterate")) cube.Iterate();
            if(GUILayout.Button("Reset Iterations")) cube.ResetIterations();
        GUILayout.EndHorizontal();
        GUILayout.Label("Mirroring Axis");
        GUILayout.BeginHorizontal();
            if (GUILayout.Button("X")) cube.Mirror(new Vector3(-1, 1, 1));
            if (GUILayout.Button("Y")) cube.Mirror(new Vector3(1, -1, 1));
            if (GUILayout.Button("Z")) cube.Mirror(new Vector3(1, 1, -1));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
            if (GUILayout.Button("XY")) cube.Mirror(new Vector3(-1, -1, 1));
            if (GUILayout.Button("YZ")) cube.Mirror(new Vector3(1, -1, -1));
            if (GUILayout.Button("ZX")) cube.Mirror(new Vector3(-1, 1, -1));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
            if (GUILayout.Button("XYZ")) cube.Mirror(new Vector3(-1, -1, -1));
        GUILayout.EndHorizontal();
        EditorGUILayout.HelpBox("This script makes copies of objects that change slightly with each copy. " +
            "Make sure the \"Relative Iteration Transform\" is close to the parent transform. " +
            "Mirroring will copy the current state of the iteration, and further mirrors will operate on existing ones too.", MessageType.None);
    }
}
