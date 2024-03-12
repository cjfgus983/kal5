using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage : PatternData
{
    public GameObject stageManager;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stageManager = GameObject.Find("StageManager");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stageManager.GetComponent<StageManager>().isClear = false;
    }
}

