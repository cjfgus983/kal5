using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : PatternData
{
    public Vector3 targetPosition;
    public Vector3 targetScale;
    public float moveTime = 1f;

    private Vector3 originalDirection;

    override protected void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);

        if (gameObject.transform.position.x == -2.8) // 1번 자리
		{
            targetPosition.x = -6.2f;
        }
        else if (gameObject.transform.position.x == -1) // 2번 자리
        {
            targetPosition.x = -2f;
        }
        else if (gameObject.transform.position.x == 1) // 3번 자리
        {
            targetPosition.x = 2f;
        }
        else if (gameObject.transform.position.x == 2.8) // 4번 자리
        {
            targetPosition.x = 6.2f;
        }
        targetPosition.y = -4.0f;

        originalDirection = (targetPosition - transform.position).normalized;

        StartCoroutine(MoveAndScaleObject());
    }

    IEnumerator MoveAndScaleObject()
    {
        Vector3 initialPosition = transform.position;
        Vector3 initialScale = transform.localScale;

        float elapsedTime = 0f;

        while (elapsedTime < moveTime)
        {
            float t = elapsedTime / moveTime;

            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.localScale = targetScale;

        //이동하던 방향으로 쭉 이동하도록
        StartCoroutine(MoveInOriginalDirection());

    }
   
    IEnumerator MoveInOriginalDirection()
    {
        while (true)
        {
            transform.position += originalDirection * Time.deltaTime * 100;

            yield return null;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
            gameObject.SetActive(false);
		}
	}
}
