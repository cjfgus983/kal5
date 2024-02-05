using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject lazerAttack;
    public float timeDestroy = 1f;

    

    void Start()
    {
        
        // Start �޼��忡�� 1�� �ڿ� LazerAttackCoroutine ȣ��
        StartCoroutine(LazerAttackCoroutine());
    }

    void Update()
    {
    
    }

    IEnumerator LazerAttackCoroutine()
    {
        // �� ������Ʈ�� ȸ��
        Quaternion rotation = transform.rotation;
        Vector3 spawnPosition = transform.position + rotation * new Vector3(0, 0.15f, -1);

        //���� �� 1�� ���
        yield return new WaitForSeconds(1f);

        // �߻��ϰ� 1�� ���
        GameObject lazerAttackObject = Instantiate(lazerAttack, spawnPosition, rotation);
        lazerAttackObject.transform.parent = transform.parent;
        yield return new WaitForSeconds(1f);

        // ������Ʈ ����
        gameObject.SetActive(false);
    }
}
