using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightBullet : PatternData
{
    public float moveSpeed = 5f; // 이동 속도 조절을 위한 변수
    public Vector3 moveDirection = Vector3.right; // 움직일 방향을 설정

    protected override void Update()
    {
        // Time.deltaTime을 사용하여 이동을 부드럽게 만듭니다.
        // moveSpeed를 조절하여 이동 속도를 설정할 수 있습니다.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

}
