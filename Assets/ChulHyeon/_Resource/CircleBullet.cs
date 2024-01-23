using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : PatternData
{
    public GameObject bullet;

    public int count = 3; // 몇 번 발사할지
    public float interval = 0.7f; // 발사간의 간격

    private int remain;
    protected override void Start()
    {
        remain = count;
        Fire();
    }


    protected override void Update()
    {
        
    }

	void Fire()
	{
        int roundNumA = 50;
        int roundNumB = 40;
        int cnt = count;
        int roundNum = cnt % 2 == 0 ? roundNumA : roundNumB;

        for (int i = 0; i < roundNum; i++)
        {
            float angle = i * 360f / roundNum; // 각도 계산

            // 극좌표를 직교좌표로 변환
            float x = Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = Mathf.Sin(angle * Mathf.Deg2Rad);

            // 생성 위치 조정 (예: 원의 중심으로부터 반지름 2만큼 떨어진 위치)
            Vector3 spawnPosition = new Vector3(x, y, 0);

            // 총알 생성
            GameObject newBullet = Instantiate(bullet, transform.position + spawnPosition, Quaternion.identity);

            Vector3 rotVec = Vector3.forward * 360 * i / roundNum + Vector3.forward * (-90);
            newBullet.transform.Rotate(rotVec);

            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(spawnPosition.normalized * 5, ForceMode2D.Impulse);
        }

        remain--;
        if(remain > 0)
		{
            Invoke("Fire", interval);
		}
    }
}
