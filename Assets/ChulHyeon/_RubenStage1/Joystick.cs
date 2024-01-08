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
		//드래그 하는 동안
		if(isDrag)
		{
			Vector2 vec = Input.mousePosition - backCircle.position;
			//마우스에서 스틱 중심값을 뺀 값의 최대값을 limit까지만으로 한정짓는다
			stick.localPosition = Vector2.ClampMagnitude(vec, limit); //어떤 값을 얼마만큼 제한할것인지 

			Vector3 dir = (stick.position - backCircle.position).normalized;
			player.transform.position += dir * player.GetComponent<Player>().speed * Time.deltaTime;

			//드래그 끝나면
			if (Input.GetMouseButtonUp(0))
			{
				stick.localPosition = new Vector3(0, 0, 0);
				isDrag = false;
			}
		}
	}
	//스틱 누르면 호출

	public void ClickStick()
	{
		isDrag = true;
	}
}
