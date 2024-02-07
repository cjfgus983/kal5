using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : PatternData
{
    public Vector3 targetPosition;
    public Vector3 targetScale;
    public float moveTime = 3f;

    protected Vector3 originalDirection;

    public GameObject redNode;

    override protected void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);

        if (gameObject.transform.position.x < -2.6f) // 1번 자리
		{
            targetPosition.x = -6.2f;
            GameObject rednode1 = Instantiate(redNode, new Vector3(-1,4,0), Quaternion.Euler(0, 0, 90) );
            GameObject rednode2 = Instantiate(redNode, new Vector3(1, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode3 = Instantiate(redNode, new Vector3(2.8f, 4, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (gameObject.transform.position.x == -1) // 2번 자리
        {
            targetPosition.x = -2f;
            GameObject rednode1 = Instantiate(redNode, new Vector3(-2.8f, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode2 = Instantiate(redNode, new Vector3(1, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode3 = Instantiate(redNode, new Vector3(2.8f, 4, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (gameObject.transform.position.x == 1) // 3번 자리
        {
            targetPosition.x = 2f;
            GameObject rednode1 = Instantiate(redNode, new Vector3(-2.8f, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode2 = Instantiate(redNode, new Vector3(-1, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode3 = Instantiate(redNode, new Vector3(2.8f, 4, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (gameObject.transform.position.x > 2.6f) // 4번 자리
        {
            targetPosition.x = 6.2f;
            GameObject rednode1 = Instantiate(redNode, new Vector3(-2.8f, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode2 = Instantiate(redNode, new Vector3(-1, 4, 0), Quaternion.Euler(0, 0, 90));
            GameObject rednode3 = Instantiate(redNode, new Vector3(1, 4, 0), Quaternion.Euler(0, 0, 90));
        }
        targetPosition.y = -4.0f;

        originalDirection = (targetPosition - transform.position).normalized;

        StartCoroutine(MoveAndScaleObject());
    }

    protected virtual IEnumerator MoveAndScaleObject()
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

        //이동하던 방향으로 쭉 이동하도록
        StartCoroutine(MoveInOriginalDirection());
    }

    IEnumerator MoveRed (GameObject redNode)
    {
        Vector3 initialPosition = redNode.transform.position;
        Vector3 initialScale = redNode.transform.localScale;

        Vector3 targetPosition_red;
        targetPosition_red = new Vector3(0, -4f, 0);
        if (redNode.transform.position.x == -2.8) //만약 레드 노드의 생성 자리가 -2.8이면
		{
            targetPosition_red.x = -6.2f;
        }
        else if(redNode.transform.position.x == -1)
		{
            targetPosition_red.x = -2f;
        }
        else if (redNode.transform.position.x == 1)
        {
            targetPosition_red.x = 2f;
        }
        else if (redNode.transform.position.x == 2.8)
        {
            targetPosition_red.x = 6.2f;
        }

        float elapsedTime = 0f;
        while (elapsedTime < moveTime)
        {
            float t = elapsedTime / moveTime;

            redNode.transform.position = Vector3.Lerp(initialPosition, targetPosition_red, t);

            Vector3 newScale = transform.localScale;
            newScale.y = Mathf.Lerp(initialScale.y, 1.9f, t);
            transform.localScale = newScale;    

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        redNode.transform.position = targetPosition_red;
        redNode.transform.localScale = targetScale;

        //이동하던 방향으로 쭉 이동하도록
    }

    protected IEnumerator MoveInOriginalDirection()
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
