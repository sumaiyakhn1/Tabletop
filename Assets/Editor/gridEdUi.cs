using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(gridEdNor))]
public class gridEdUi : Editor
{


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        gridEdNor _inst = (gridEdNor)target;
        if(GUILayout.Button("create"))
        {
            _inst.create();
            
        }
    }

}
