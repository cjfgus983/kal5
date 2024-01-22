using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject danger;
    public GameObject longRed;


    void Start()
    {
        GameObject dangerObject = Instantiate(danger, transform.position, Quaternion.identity);
        dangerObject.transform.parent = transform;
        // 2�� �Ŀ� RemoveObject �Լ� ȣ��
        Invoke("RemoveObject", 2f);
    }

    void Update()
    {
    }
    void RemoveObject()
    {
        // �� ������Ʈ�� ȸ��
        Quaternion rotation = transform.rotation;
        // ������Ʈ�� ��ġ - ȸ���� ��ŭ���� y�� -5
        Vector3 spawnPosition = transform.position - rotation * new Vector3(0, 5f, 0);
        Instantiate(longRed, spawnPosition, rotation);
        // ���� ������Ʈ�� �� �ڽĵ��� ��� ����
        Destroy(gameObject);
    }
}
