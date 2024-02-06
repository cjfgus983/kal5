using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBulletPattern : PatternData
{
    public float moveSpeed = 5f; // 이동 속도 조절을 위한 변수
    private Transform player; // 플레이어의 Transform을 저장할 변수
    public Vector3 moveDirection;
    public int bulletCount = 5; // 생성할 총알의 개수
    public float bulletSpreadAngle = 10f; // 총알 간의 각도
    public straightBullet bulletPrefab; // 총알 프리팹

    protected override void Start()
    {
        base.Start();

        // 플레이어의 Transform을 찾아 변수에 할당합니다.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }

        if (player != null)
        {
            // 총알의 현재 위치와 플레이어의 위치 출력
            Debug.Log("Bullet Position: " + transform.position);
            Debug.Log("Player Position: " + player.position);

            // 플레이어의 위치를 향해 이동 방향을 설정
            moveDirection = (player.position - transform.position).normalized;
        }
        else
        {
            Debug.LogError("Player is null!");
        }
        for (int i = 0; i < bulletCount; i++)
        {
            // 현재 총알의 방향을 계산
            float angle = i * bulletSpreadAngle - (bulletCount - 1) * bulletSpreadAngle / 2f;
            Vector3 currentBulletDirection = Quaternion.Euler(0f, 0f, angle) * moveDirection;

            // 총알 생성 및 발사
            straightBullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            if (bullet != null)
            {
                // CustomBulletPattern의 moveDirection 변수를 설정합니다.
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