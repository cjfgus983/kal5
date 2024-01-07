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

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

	void Update()
    {
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
        if (h==-1)
		{
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;

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
}
