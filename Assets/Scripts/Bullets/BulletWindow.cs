using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(BulletManager))]
[CanEditMultipleObjects]
public class BulletWindow : Editor
{
    private BulletManager bm;

    private void OnEnable()
    {
        bm = target as BulletManager;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Bullet"))
        {
            bm.GetComponent<BulletManager>().CreateBullet();
        }
    }
}
#endif