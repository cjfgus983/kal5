using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedClap : PatternData
{
    //public GameObject player;
    public GameObject newObjectPrefab; // 새로운 오브젝트 프리팹 설정
    public GameObject magmaController; // 마그마 컨트롤러

    public float stopAndStayTime = 1f; // 1초 뒤에 멈춤

    public float blinkInterval = 0.1f;
    private Renderer objectRenderer;

    private float elapsedTime = 0f;

    Vector2 randomPos;

    bool keepMake = true;

    protected override void Start()
    {
        magmaController = GameObject.Find("magmaController");
        objectRenderer = GetComponent<Renderer>();

        Color currentColor = objectRenderer.material.color;
        currentColor.a = 0.3f;
        objectRenderer.material.color = currentColor;

        //float randomX = Random.Range(-8f, 8f);
        //float fixedY = Random.Range(-4f, 4f);
        //randomPos = new Vector2(randomX, fixedY);
        //transform.position = randomPos;

        InvokeRepeating("ToggleAlpha", 0f, blinkInterval);
    }

    protected override void Update()
    {

        if (elapsedTime >= patDuration && keepMake)
        {

            SpawnNewObject();
            Destroy(gameObject);
        }
        else if(elapsedTime < patDuration)
            elapsedTime += Time.deltaTime; 
    }

    private void ToggleAlpha()
    {
        Color currentColor = objectRenderer.material.color;
        currentColor.a = (currentColor.a == 0.3f) ? 0.7f : 0.3f;
        objectRenderer.material.color = currentColor;
    }
 
    private void SpawnNewObject()
    {
        // 현재 오브젝트와 동일한 위치에 새로운 오브젝트 생성
        GameObject newObject = Instantiate(newObjectPrefab, transform.position, Quaternion.identity, transform);
        newObject.transform.parent = magmaController.transform;
    }
}
