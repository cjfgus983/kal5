using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //플레이어 이동속도
    public float speed;
    //border에 닿았을 때
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;
    SpriteRenderer spriteRenderer;

    public bool getDamage = false;

    public bool rythmMode = false;
    private bool isInRythmMode = false; // 처음 리듬게임모드로 들어갔을 때 위치 고정 위함
    private bool isHorizontalInputPressed = false;
    private float[] rythmXPositions = { -6f, -1f, 1f, 6f };
    private int currentRythmIndex = 1; // 시작 위치는 0이 아닌 1로 설정
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

	void Update()
    {
        if(rythmMode) //리듬게임 모드 일 때
		{
            if (!isInRythmMode)// 처음 진입할 때 위치 고정
            {
                isInRythmMode = true;
                StartCoroutine(MoveToRythmPosition(new Vector3(rythmXPositions[currentRythmIndex], -4f, 0f), 1f)); // 1초 동안 이동
            }
            float h = Input.GetAxisRaw("Horizontal");
            if (h == -1 && !isHorizontalInputPressed) // 처음 왼쪽 키를 누른 상태라면
            {
                isHorizontalInputPressed = true; //누른 상태로 변경하고
                if(currentRythmIndex != 0) // 가장 왼쪽에 있는 상황이 아닐 때만
				{
                    currentRythmIndex -= 1;
                }
            }
            else if (h == 1 && !isHorizontalInputPressed)
            {
                isHorizontalInputPressed = true; //누른 상태로 변경하고
                if (currentRythmIndex != 3) // 가장 오른쪽에 있는 상황이 아닐 때만
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

		else // 기본 움직임
		{
            if(isInRythmMode) //리듬게임 모드에서 탈출하면
			{
                StartCoroutine(MoveToRythmPosition(new Vector3(0f, 0f, 0f), 1f)); // 1초 동안 이동
                isInRythmMode = false;
            }


            //플레이어 이동
            float h = Input.GetAxisRaw("Horizontal");
            ////Border움직임 제한
            if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
                h = 0;
            float v = Input.GetAxisRaw("Vertical");
            ///Border움직임 제한
            if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
                v = 0;
            Vector3 curPos = transform.position;
            Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;
            transform.position = curPos + nextPos;
            //플레이어 방향전환
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
        //Border에 닿았을 때
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
        //장애물에 닿았을 때
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("attacked");
            getDamage = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.7f);
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        //Border에서 나왔을 때
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
        //장애물 탈출
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

        transform.position = targetPosition; // 정확한 위치로 보정
    }
}


