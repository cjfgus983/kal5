using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaController : MonoBehaviour
{
    private void Update()
    {
        // �� ������Ʈ�� �ڽ� ������ 8�� �̻��̸� ��� �ڽ� ������Ʈ�� ����
        if (transform.childCount >= 16)
        {
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}
    }
}
