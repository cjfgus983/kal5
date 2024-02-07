using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScreen : MonoBehaviour
{
    public float startMove = 3.6f;
    public float moveDuration = 0.8f; // 이동에 걸리는 시간

    float currentTime = 0f;
    float elapsedTime = 0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    public Color startColor = Color.black; // 시작 색상
    public Color endColor = Color.red; // 끝 색상

    private Renderer rendererComponent;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(-19f, startPosition.y, startPosition.z);
        rendererComponent = GetComponent<Renderer>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= startMove)
        {
            if (elapsedTime < moveDuration)
            {
                float t = elapsedTime / moveDuration;
                float smoothT = Mathf.SmoothStep(0f, 1f, t); // 느리게 시작하여 빠르게 끝나도록 보간
                // 보간 계산
                transform.position = Vector3.Lerp(startPosition, targetPosition, smoothT);

                // 색상의 알파값과 RGB 보간 계산
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / moveDuration);
                Color lerpedColor = Color.Lerp(startColor, endColor, smoothT);
                rendererComponent.material.color = new Color(lerpedColor.r, lerpedColor.g, lerpedColor.b, alpha);

                // 경과 시간 증가
                elapsedTime += Time.deltaTime;
            }
        }
    }
}
