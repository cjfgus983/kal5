using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueBullet1 : PatternData
{
    Vector2 randomPos;
    //public float initialSpeed = 2f;
    //public float accelerationRate = 0.1f; // 가속도


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
        // 아래 이동은 그냥 중력으로 해결
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
        // 현재 속도 계산 (처음에는 initialSpeed, 점점 가속됨)
        //float currentSpeed = initialSpeed + accelerationRate * Time.time;

        // 아래로 이동
        //transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
    }

}
