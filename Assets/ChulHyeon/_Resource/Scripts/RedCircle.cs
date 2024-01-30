using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCircle : MonoBehaviour
{
    public float moveSpeed = 2f;//��Ʋ�Ÿ��� �ӵ�
    public float waitTime = .5f;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedStartCoroutine());
    }

    IEnumerator DelayedStartCoroutine() //�����ؼ� ��ũ���߱�� �Լ�
    {
        // 5�� ���
        yield return new WaitForSeconds(waitTime);

        // ���Ŀ� ����ؼ� �̵��ϴ� �ڷ�ƾ ����
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(WigglyMoveCoroutine());
    }

    IEnumerator WigglyMoveCoroutine()
    {
        float t = 0f;
        while (true)
        {
            // �����ϴ� ����ġ�� ������� �̵�
            t += Time.deltaTime * moveSpeed;

            // Lerp�� ����Ͽ� �ε巯�� �̵�
            Vector2 offset = new Vector2(Mathf.PingPong(t, 2f) - 1f, 0f); // -1~1 ���� �� (-1~1, 0)
            Vector3 rotatedOffset = transform.rotation * offset; //ȸ���� ���� x y�� 
            Vector2 targetPosition = new Vector2(rotatedOffset.x + transform.position.x, rotatedOffset.y + transform.position.y);
            transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            yield return null;
        }
    }
}
