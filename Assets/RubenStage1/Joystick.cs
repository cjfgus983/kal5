using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
	public RectTransform stick;
	public RectTransform backCircle;
	public GameObject player;

	bool isDrag;
	float limit;

	private void Start()
	{
		limit = backCircle.rect.width * 0.5f;
	}

	private void Update()
	{
		//�巡�� �ϴ� ����
		if(isDrag)
		{
			Vector2 vec = Input.mousePosition - backCircle.position;
			//���콺���� ��ƽ �߽ɰ��� �� ���� �ִ밪�� limit���������� �������´�
			stick.localPosition = Vector2.ClampMagnitude(vec, limit); //� ���� �󸶸�ŭ �����Ұ����� 

			Vector3 dir = (stick.position - backCircle.position).normalized;
			player.transform.position += dir * player.GetComponent<Player>().speed * Time.deltaTime;

			//�巡�� ������
			if (Input.GetMouseButtonUp(0))
			{
				stick.localPosition = new Vector3(0, 0, 0);
				isDrag = false;
			}
		}
	}
	//��ƽ ������ ȣ��

	public void ClickStick()
	{
		isDrag = true;
	}
}
