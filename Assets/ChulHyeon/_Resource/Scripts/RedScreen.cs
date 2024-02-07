using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScreen : MonoBehaviour
{
    public float startMove = 3.6f;
    public float moveDuration = 0.8f; // �̵��� �ɸ��� �ð�

    float currentTime = 0f;
    float elapsedTime = 0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    public Color startColor = Color.black; // ���� ����
    public Color endColor = Color.red; // �� ����

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
                float smoothT = Mathf.SmoothStep(0f, 1f, t); // ������ �����Ͽ� ������ �������� ����
                // ���� ���
                transform.position = Vector3.Lerp(startPosition, targetPosition, smoothT);

                // ������ ���İ��� RGB ���� ���
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / moveDuration);
                Color lerpedColor = Color.Lerp(startColor, endColor, smoothT);
                rendererComponent.material.color = new Color(lerpedColor.r, lerpedColor.g, lerpedColor.b, alpha);

                // ��� �ð� ����
                elapsedTime += Time.deltaTime;
            }
        }
    }
}
