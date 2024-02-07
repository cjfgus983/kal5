using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject lazerAttack;
    public float timeDestroy = 1f;
    Vector3 forwardDirection;


    void Start()
    {
        forwardDirection = transform.right * (-1);
        // Start 메서드에서 1초 뒤에 LazerAttackCoroutine 호출
        StartCoroutine(LazerAttackCoroutine());

    }

    void Update()
    {
        if(transform.position.x > -13.27)
		{
            
            transform.Translate(forwardDirection * 30 * Time.deltaTime, Space.World);
        }
    }

    IEnumerator LazerAttackCoroutine()
    {
        // 이 오브젝트의 회전
        Quaternion rotation = transform.rotation;
        Vector3 spawnPosition = transform.position  + rotation * new Vector3(-25, 0.15f, -1);

        //생성 후 1초 대기
        yield return new WaitForSeconds(1f);

        // 발사하고 1초 대기
        GameObject lazerAttackObject = Instantiate(lazerAttack, spawnPosition, rotation);
        lazerAttackObject.transform.parent = transform.parent;
        yield return new WaitForSeconds(1f);

        // 오브젝트 삭제
        gameObject.SetActive(false);
    }
}
