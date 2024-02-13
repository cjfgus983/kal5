using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : PatternData
{
    public GameObject bullet;

    public int count = 3; // �� �� �߻�����
    public float interval = 0.7f; // �߻簣�� ����

    public int roundNumA = 20;
    public int roundNumB = 15;

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
        int cnt = count;
        int roundNum = cnt % 2 == 0 ? roundNumA : roundNumB;

        for (int i = 0; i < roundNum; i++)
        {
            float angle = i * 360f / roundNum; // ���� ���

            // ����ǥ�� ������ǥ�� ��ȯ
            float x = Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector3 spawnPosition = new Vector3(x, y, 0);

            // �Ѿ� ����
            GameObject newBullet = Instantiate(bullet, transform.position + spawnPosition, Quaternion.identity);

            Vector3 rotVec = Vector3.forward * 360 * i / roundNum + Vector3.forward * (-90); // 0 ~ 360 ���� ȸ��
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
