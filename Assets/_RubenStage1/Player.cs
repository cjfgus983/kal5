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

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

	void Update()
    {
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
        if (h==-1)
		{
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;

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
}
