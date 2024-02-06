using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightBullet : PatternData
{
    public float moveSpeed = 5f;
    public Vector3 moveDirection = Vector3.right;


    protected override void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
