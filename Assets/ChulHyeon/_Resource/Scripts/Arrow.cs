using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : PatternData
{
    public float moveSpeed = 5f;

	protected override void Start()
	{
	    if(transform.position.x > 3) //��
		{
            transform.rotation = Quaternion.identity;
        }
        else if (transform.position.x < -3) //��
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
		{
            if (transform.position.y > 3) //��
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (transform.position.x > 3) //�Ʒ�
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
    }

	protected override void Update()
    {
        // �������� �̵�
        MoveLeft();
    }

     void MoveLeft()
    {
        // ���� �������� �̵�
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }


}
