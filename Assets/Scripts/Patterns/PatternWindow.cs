using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(PatternManager))]
[CanEditMultipleObjects]
public class PatternWindow : Editor 
{
    private PatternManager pm;
    
    private void OnEnable()
    {
        pm = target as PatternManager;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Add Pattern"))
        {
            pm.GetComponent<PatternManager>().AddPattern();
        }
    }


}
#endif
