using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //�÷��̾� �̵��ӵ�
    public float speed;
    //border�� ����� ��
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;
    SpriteRenderer spriteRenderer;

    public bool getDamage = false;

    public bool rythmMode = false;
    private bool isInRythmMode = false; // ó�� ������Ӹ��� ���� �� ��ġ ���� ����
    private bool isHorizontalInputPressed = false;
    private float[] rythmXPositions = { -6f, -1f, 1f, 6f };
    private int currentRythmIndex = 1; // ���� ��ġ�� 0�� �ƴ� 1�� ����
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

	void Update()
    {
        if(rythmMode) //������� ��� �� ��
		{
            if (!isInRythmMode)// ó�� ������ �� ��ġ ����
            {
                isInRythmMode = true;
                StartCoroutine(MoveToRythmPosition(new Vector3(rythmXPositions[currentRythmIndex], -4f, 0f), 1f)); // 1�� ���� �̵�
            }
            float h = Input.GetAxisRaw("Horizontal");
            if (h == -1 && !isHorizontalInputPressed) // ó�� ���� Ű�� ���� ���¶��
            {
                isHorizontalInputPressed = true; //���� ���·� �����ϰ�
                if(currentRythmIndex != 0) // ���� ���ʿ� �ִ� ��Ȳ�� �ƴ� ����
				{
                    currentRythmIndex -= 1;
                }
            }
            else if (h == 1 && !isHorizontalInputPressed)
            {
                isHorizontalInputPressed = true; //���� ���·� �����ϰ�
                if (currentRythmIndex != 3) // ���� �����ʿ� �ִ� ��Ȳ�� �ƴ� ����
                {
                    currentRythmIndex += 1;
                }
            }
            else if (h == 0 && isHorizontalInputPressed)
            {
                isHorizontalInputPressed = false;
            }
            transform.position = new Vector3(rythmXPositions[currentRythmIndex], -4f, 0f);
        }

		else // �⺻ ������
		{
            if(isInRythmMode) //������� ��忡�� Ż���ϸ�
			{
                StartCoroutine(MoveToRythmPosition(new Vector3(0f, 0f, 0f), 1f)); // 1�� ���� �̵�
                isInRythmMode = false;
            }


            //�÷��̾� �̵�
            float h = Input.GetAxisRaw("Horizontal");
            ////Border������ ����
            if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
                h = 0;
            float v = Input.GetAxisRaw("Vertical");
            ///Border������ ����
            if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
                v = 0;
            Vector3 curPos = transform.position;
            Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;
            transform.position = curPos + nextPos;
            //�÷��̾� ������ȯ
            if (h == -1)
            {
                spriteRenderer.flipX = true;
            }
            else
                spriteRenderer.flipX = false;
        }
    }
	void OnTriggerEnter2D(Collider2D collision)
	{
        //Border�� ����� ��
        if(collision.gameObject.tag == "Border")
		{
            switch(collision.gameObject.name)
			{
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;

            }
		}
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        //��ֹ��� ����� ��
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("attacked");
            getDamage = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.7f);
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        //Border���� ������ ��
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;

            }
        }
        //��ֹ� Ż��
        if (collision.gameObject.tag == "Obstacle")
        {
            
            Debug.Log("exit");
            getDamage = false;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
    IEnumerator MoveToRythmPosition(Vector3 targetPosition, float moveTime)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // ��Ȯ�� ��ġ�� ����
    }
}


