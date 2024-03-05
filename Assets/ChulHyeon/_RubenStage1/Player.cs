using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public bool getDamage = false;

    public bool rythmMode = false;
    private bool isInRythmMode = false; // 처음 리듬게임모드로 들어갔을 때 위치 고정 위함
    //private bool isHorizontalInputPressed = false;
    //private float[] rythmXPositions = { -6f, -1f, 1f, 6f };
    //private int currentRythmIndex = 1; // 시작 위치는 0이 아닌 1로 설정

    public GameObject sheild;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        sheild.SetActive(false);
    }

	void Update()
    {
        if(rythmMode) //리듬게임 모드 일 때
		{
            if (!isInRythmMode)// 처음 진입할 때 위치 고정
            {
                isInRythmMode = true;
                StartCoroutine(MoveToRythmPosition(new Vector3(0f, 0f, 0f), 0.1f)); // 1초 동안 이동
                
            }
            sheild.SetActive(true);
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if(h ==1) // 오
			{
                sheild.transform.position = new Vector3(1f, 0, 0);
                sheild.transform.rotation = Quaternion.identity;
            }
            if (h == -1) //왼
            {
                sheild.transform.position = new Vector3(-1f, 0, 0);
                sheild.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (v == -1) //아래
            {
                sheild.transform.position = new Vector3(0, -1f, 0);
                sheild.transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            if (v == 1) //위
            {
                sheild.transform.position = new Vector3(0, 1f, 0);
                sheild.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
		else { sheild.SetActive(false); }
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


