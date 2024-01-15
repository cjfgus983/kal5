using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmnidirectionalShell : PatternData
{
    public int shotpoint;
    BulletManager bm;
    private void Awake()
    {
        bm.GetComponent<BulletManager>();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
