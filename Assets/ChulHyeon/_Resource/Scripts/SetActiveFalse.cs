using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    public float destroy = 5.0f;

    void Start()
    {
        // ���۰� ���ÿ� �ڷ�ƾ ����
        StartCoroutine(DisableAfterDelay(destroy));
    }

    IEnumerator DisableAfterDelay(float delay)
    {
        // delay �� ��ٸ�
        yield return new WaitForSeconds(delay);

        // 3�� �ڿ� �ش� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
