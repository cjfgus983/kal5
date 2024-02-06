using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingBullet : PatternData
{
    public bool enableFeature = true;
    public float moveSpeed = 5f; // �̵� �ӵ� ������ ���� ����
    private Transform player; // �÷��̾��� Transform�� ������ ����
    public Vector3 moveDirection;

    protected override void Start()
    {
        base.Start();

        // �÷��̾��� Transform�� ã�� ������ �Ҵ��մϴ�.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
        if (player != null)
        {
            // �Ѿ��� ���� ��ġ�� �÷��̾��� ��ġ ���
            Debug.Log("Bullet Position: " + transform.position);
            Debug.Log("Player Position: " + player.position);

            // �÷��̾��� ��ġ�� ���� �̵� ������ ����
            moveDirection = (player.position - transform.position).normalized;

            // Time.deltaTime�� ����Ͽ� �̵��� �ε巴�� ����ϴ�.
            // moveSpeed�� �����Ͽ� �̵� �ӵ��� ������ �� �ֽ��ϴ�.       }
        }
        else
        {
            Debug.LogError("Player is null!");
        }
    }

    protected override void Update()
    {
      transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}