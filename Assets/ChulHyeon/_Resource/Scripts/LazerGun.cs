using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : PatternData
{
    // Start is called before the first frame update
    protected override void Start()
    {
        Invoke("RemoveObject", 2f);
    }
    void RemoveObject()
    {
        Destroy(gameObject);
    }
}
