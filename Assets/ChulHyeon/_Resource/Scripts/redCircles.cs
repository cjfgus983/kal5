using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCircles : RedCircle
{
	public float speed = 4;

	protected override void Start()
	{
		waitTime = Random.Range(0f, 1f);
		base.Start();
	}

	override protected void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
