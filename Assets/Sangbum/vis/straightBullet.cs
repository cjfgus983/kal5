using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightBullet : PatternData
{
    public float moveSpeed = 5f; // �̵� �ӵ� ������ ���� ����
    public Vector3 moveDirection = Vector3.right; // ������ ������ ����

    protected override void Update()
    {
        // Time.deltaTime�� ����Ͽ� �̵��� �ε巴�� ����ϴ�.
        // moveSpeed�� �����Ͽ� �̵� �ӵ��� ������ �� �ֽ��ϴ�.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

}
