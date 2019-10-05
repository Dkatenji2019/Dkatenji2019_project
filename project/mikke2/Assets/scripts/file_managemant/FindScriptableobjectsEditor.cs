using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FindScriptableobjects))]
public class FindScriptableobjectsEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FindScriptableobjects findScriptableobjects = target as FindScriptableobjects;

        GUILayout.Space(50);

        //元のInspector部分を表示
        if (GUILayout.Button("適用"))
        {
            findScriptableobjects.find_scriptableobjects_in_folda();
        }
    }

}
