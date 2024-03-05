using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : PatternData
{
    public GameObject danger;
    public GameObject longRed;

    public GameObject player;

    protected override void Start()
    {
        GameObject dangerObject = Instantiate(danger, transform.position, Quaternion.identity);
        dangerObject.transform.parent = transform;
        // 2초 후에 RemoveObject 함수 호출
        Invoke("RemoveObject", 1f);

        player = GameObject.Find("Player");
    }

    protected override void Update()
    {
		Vector3 newPosition = transform.position;
		newPosition.x = player.transform.position.x;
		transform.position = newPosition;

	}
    void RemoveObject()
    {
        // 이 오브젝트의 회전
        Quaternion rotation = transform.rotation;
        // 오브젝트의 위치 - 회전된 만큼에서 y축 -5
        Vector3 spawnPosition = transform.position - rotation * new Vector3(0, 10f, 0);
        Instantiate(longRed, spawnPosition, rotation);
        // 현재 오브젝트와 그 자식들을 모두 삭제
        Destroy(gameObject);
    }
}
