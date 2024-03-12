using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    public float destroy = 5.0f;

    void Start()
    {
        // 시작과 동시에 코루틴 시작
        StartCoroutine(DisableAfterDelay(destroy));
    }

    IEnumerator DisableAfterDelay(float delay)
    {
        // delay 초 기다림
        yield return new WaitForSeconds(delay);

        // 3초 뒤에 해당 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
}
