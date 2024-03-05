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
        // 2�� �Ŀ� RemoveObject �Լ� ȣ��
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
        // �� ������Ʈ�� ȸ��
        Quaternion rotation = transform.rotation;
        // ������Ʈ�� ��ġ - ȸ���� ��ŭ���� y�� -5
        Vector3 spawnPosition = transform.position - rotation * new Vector3(0, 10f, 0);
        Instantiate(longRed, spawnPosition, rotation);
        // ���� ������Ʈ�� �� �ڽĵ��� ��� ����
        Destroy(gameObject);
    }
}
