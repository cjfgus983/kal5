using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject lazerAttack;

    void Start()
    {
        // Start 메서드에서 1초 뒤에 LazerAttackCoroutine 호출
        StartCoroutine(LazerAttackCoroutine());
    }

    void Update()
    {
        // 추가적인 로직이 필요한 경우 여기에 구현
    }

    IEnumerator LazerAttackCoroutine()
    {
        // 이 오브젝트의 회전
        Quaternion rotation = transform.rotation;
        Vector3 spawnPosition = transform.position + rotation * new Vector3(0, 0.15f, -1);


        // 1초 대기
        yield return new WaitForSeconds(1f);

        // 새로운 오브젝트를 생성하고, 1초 대기
        GameObject lazerAttackObject = Instantiate(lazerAttack, spawnPosition, rotation);
        yield return new WaitForSeconds(1f);

        // 두 오브젝트를 삭제

        Destroy(lazerAttackObject);
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }
}
