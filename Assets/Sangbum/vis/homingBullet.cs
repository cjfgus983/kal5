using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingBullet : PatternData
{
    public bool enableFeature = true;
    public float moveSpeed = 5f; // 이동 속도 조절을 위한 변수
    private Transform player; // 플레이어의 Transform을 저장할 변수
    public Vector3 moveDirection;

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

            // Time.deltaTime을 사용하여 이동을 부드럽게 만듭니다.
            // moveSpeed를 조절하여 이동 속도를 설정할 수 있습니다.       }
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