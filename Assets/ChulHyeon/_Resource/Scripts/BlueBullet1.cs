using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueBullet1 : PatternData
{
    Vector2 randomPos;
    //public float initialSpeed = 2f;
    //public float accelerationRate = 0.1f; // ���ӵ�


    protected override void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,180);

        SetRandomPosition();
        StartCoroutine(SetFalse());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //MoveBulletDown();
        // �Ʒ� �̵��� �׳� �߷����� �ذ�
    }

    void SetRandomPosition()
    {
        float randomX = Random.Range(-16.5f, 16.5f);
        float fixedY = 7.5f;
        randomPos = new Vector2(randomX, fixedY);
        transform.position = randomPos;
    }
    void MoveBulletDown()
    {
        // ���� �ӵ� ��� (ó������ initialSpeed, ���� ���ӵ�)
        //float currentSpeed = initialSpeed + accelerationRate * Time.time;

        // �Ʒ��� �̵�
        //transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
    }

}
