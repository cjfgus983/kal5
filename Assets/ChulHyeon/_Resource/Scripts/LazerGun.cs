using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : PatternData
{
    public GameObject lazerpointerPrefab; // �߻��� �Ѿ� ������
    public GameObject lazerPrefab; // �߻��� �Ѿ� ������

    public float pointerSpeed = 50f; // �Ѿ� �߻� �ӵ�
    protected override void Start()
    {
        // �Ѿ��� �����ϰ� �ʱ� ��ġ�� ȸ���� ���� ��ġ�� ȸ���� �°� ����
        Quaternion rotation = transform.rotation;
        Vector3 spawnPosition = transform.position + rotation * new Vector3(9f, -0.15f, 0f);
        GameObject lazerpointer = Instantiate(lazerpointerPrefab, spawnPosition, transform.rotation);

        // �Ѿ˿� �ӵ��� �����Ͽ� �߻�
        lazerpointer.GetComponent<Rigidbody2D>().velocity = transform.right * (-1) * pointerSpeed;

        // �Ѿ��� ��� �ð� �Ŀ� �ı����� ���� (��: 1�� �Ŀ� �ı�)
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
