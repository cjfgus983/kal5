using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public bool getDamage = false;

    public bool rythmMode = false;
    private bool isInRythmMode = false; // ó�� ������Ӹ��� ���� �� ��ġ ���� ����
    //private bool isHorizontalInputPressed = false;
    //private float[] rythmXPositions = { -6f, -1f, 1f, 6f };
    //private int currentRythmIndex = 1; // ���� ��ġ�� 0�� �ƴ� 1�� ����

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
        if(rythmMode) //������� ��� �� ��
		{
            if (!isInRythmMode)// ó�� ������ �� ��ġ ����
            {
                isInRythmMode = true;
                StartCoroutine(MoveToRythmPosition(new Vector3(0f, 0f, 0f), 0.1f)); // 1�� ���� �̵�
                
            }
            sheild.SetActive(true);
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if(h ==1) // ��
			{
                sheild.transform.position = new Vector3(1f, 0, 0);
                sheild.transform.rotation = Quaternion.identity;
            }
            if (h == -1) //��
            {
                sheild.transform.position = new Vector3(-1f, 0, 0);
                sheild.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (v == -1) //�Ʒ�
            {
                sheild.transform.position = new Vector3(0, -1f, 0);
                sheild.transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            if (v == 1) //��
            {
                sheild.transform.position = new Vector3(0, 1f, 0);
                sheild.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
		else { sheild.SetActive(false); }
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


