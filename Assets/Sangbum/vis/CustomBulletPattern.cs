using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBulletPattern : PatternData
{
    public float moveSpeed = 5f; // �̵� �ӵ� ������ ���� ����
    private Transform player; // �÷��̾��� Transform�� ������ ����
    public Vector3 moveDirection;
    public int bulletCount = 5; // ������ �Ѿ��� ����
    public float bulletSpreadAngle = 10f; // �Ѿ� ���� ����
    public straightBullet bulletPrefab; // �Ѿ� ������

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
        }
        else
        {
            Debug.LogError("Player is null!");
        }
        for (int i = 0; i < bulletCount; i++)
        {
            // ���� �Ѿ��� ������ ���
            float angle = i * bulletSpreadAngle - (bulletCount - 1) * bulletSpreadAngle / 2f;
            Vector3 currentBulletDirection = Quaternion.Euler(0f, 0f, angle) * moveDirection;

            // �Ѿ� ���� �� �߻�
            straightBullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            if (bullet != null)
            {
                // CustomBulletPattern�� moveDirection ������ �����մϴ�.
                bullet.moveDirection = currentBulletDirection;
                bullet.patStartTime = patStartTime;
                bullet.patDuration = patDuration;
                bullet.moveSpeed = moveSpeed;
                bullet.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Failed to instantiate homingBullet.");
            }
        }
    }

    protected override void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}