using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaController : MonoBehaviour
{
    private void Update()
    {
        // 빈 오브젝트의 자식 개수가 8개 이상이면 모든 자식 오브젝트를 삭제
        if (transform.childCount >= 16)
        {
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}
    }
}
