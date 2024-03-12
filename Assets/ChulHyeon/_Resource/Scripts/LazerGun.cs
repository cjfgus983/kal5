using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : PatternData
{
    public GameObject lazerpointerPrefab; // 발사할 총알 프리팹
    public GameObject lazerPrefab; // 발사할 총알 프리팹

    public float pointerSpeed = 50f; // 총알 발사 속도
    protected override void Start()
    {
        // 총알을 생성하고 초기 위치와 회전을 총의 위치와 회전에 맞게 설정
        Quaternion rotation = transform.rotation;
        Vector3 spawnPosition = transform.position + rotation * new Vector3(9f, -0.15f, 0f);
        GameObject lazerpointer = Instantiate(lazerpointerPrefab, spawnPosition, transform.rotation);

        // 총알에 속도를 적용하여 발사
        lazerpointer.GetComponent<Rigidbody2D>().velocity = transform.right * (-1) * pointerSpeed;

        // 총알이 어느 시간 후에 파괴될지 설정 (예: 1초 후에 파괴)
        Destroy(lazerpointer, 1f);

        StartCoroutine(SpawnLazerPrefab());

        StartCoroutine(SetFalse());

        float disT = patDuration - patStartTime;
        Invoke("RemoveObject", disT);
    }

    IEnumerator SpawnLazerPrefab()
    {
        yield return new WaitForSeconds(1f);
        Quaternion rotation = transform.rotation;
        Vector3 spawnPosition = transform.position + rotation * new Vector3(-26.7f, 0f, 0f);
        GameObject lazer = Instantiate(lazerPrefab, spawnPosition, transform.rotation);

        lazer.transform.parent = transform;
    }

	void RemoveObject()
	{
		Destroy(gameObject);
	}
}
