using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedNode : Node
{

	protected override void Start()
	{
        transform.rotation = Quaternion.Euler(0, 0, 90);

        if (gameObject.transform.position.x < -2.6f) // 1�� �ڸ�
        {
            targetPosition.x = -6.2f;
        }
        else if (gameObject.transform.position.x == -1) // 2�� �ڸ�
        {
            targetPosition.x = -2f;
        }
        else if (gameObject.transform.position.x == 1) // 3�� �ڸ�
        {
            targetPosition.x = 2f;
        }
        else if (gameObject.transform.position.x > 2.6f) // 4�� �ڸ�
        {
            targetPosition.x = 6.2f;
        }
        targetPosition.y = -4.0f;

        originalDirection = (targetPosition - transform.position).normalized;

        StartCoroutine(MoveAndScaleObject());
    }
    protected override IEnumerator MoveAndScaleObject()
    {
        Vector3 initialPosition = transform.position;
        Vector3 initialScale = transform.localScale;

        float elapsedTime = 0f;

        while (elapsedTime < moveTime)
        {
            float t = Mathf.SmoothStep(0f, 1f, elapsedTime / moveTime);

            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            Vector3 newScale = transform.localScale;
            newScale.y = Mathf.Lerp(initialScale.y, 1.9f, t);
            transform.localScale = newScale;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.localScale = targetScale;

        //�̵��ϴ� �������� �� �̵��ϵ���
        StartCoroutine(MoveInOriginalDirection());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("�÷��̾ ����");
        }
    }
}
