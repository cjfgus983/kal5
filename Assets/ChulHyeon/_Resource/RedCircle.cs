using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCircle : MonoBehaviour
{
    public float moveSpeed = 2f;//꿈틀거리는 속도
    public float waitTime = .5f;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedStartCoroutine());
    }

    IEnumerator DelayedStartCoroutine() //시작해서 싱크맞추기용 함수
    {
        // 5초 대기
        yield return new WaitForSeconds(waitTime);

        // 이후에 계속해서 이동하는 코루틴 시작
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(WigglyMoveCoroutine());
    }

    IEnumerator WigglyMoveCoroutine()
    {
        float t = 0f;
        while (true)
        {
            // 증가하는 가중치로 지그재그 이동
            t += Time.deltaTime * moveSpeed;

            // Lerp를 사용하여 부드러운 이동
            Vector2 offset = new Vector2(Mathf.PingPong(t, 2f) - 1f, 0f); // -1~1 사이 값 (-1~1, 0)
            Vector3 rotatedOffset = transform.rotation * offset; //회전에 따른 x y값 
            Vector2 targetPosition = new Vector2(rotatedOffset.x + transform.position.x, rotatedOffset.y + transform.position.y);
            transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            yield return null;
        }
    }
}
