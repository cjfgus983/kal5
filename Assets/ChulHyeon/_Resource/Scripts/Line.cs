using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float initialMovementSpeed = 0.5f;
    public float accelerationRate = 10f; // 가속도
    private float currentSpeed;
    Vector3 forwardDirection;
    private void Start()
	{
        currentSpeed = initialMovementSpeed;
        forwardDirection = transform.up * (-1);
    }
	void Update()
    {
        if(transform.position.y > 0)
		{
            // 현재 물체의 전방 방향으로 이동
            
            currentSpeed += accelerationRate * Time.deltaTime;
            transform.Translate(forwardDirection * currentSpeed * Time.deltaTime, Space.World);
        }
    }

   

    //IEnumerator MoveObject()
    //   {
    //       Vector3 initialPosition = transform.position;
    //       Quaternion startRotation = transform.rotation;

    //       float elapsedTime = 0f;

    //       while (elapsedTime < moveTime)
    //       {
    //           float t = elapsedTime / moveTime;

    //           transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
    //           transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation.eulerAngles, targetRotation, t));

    //           elapsedTime += Time.deltaTime;
    //           yield return null;
    //       }
    //       transform.position = targetPosition;
    //       transform.rotation = Quaternion.Euler(targetRotation);
    //   }
}
