using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public WaitMusic bgm;
    public GameObject line;
    public Player player; 

    public float curTime = 0f;

    public float startTime;
    public float endTime;
    float elapsedTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime = bgm.curTime;
        if(curTime >= startTime)
		{
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / 1f;
            line.transform.localScale = Vector3.Lerp(line.transform.localScale, new Vector3(0.55f,0.55f,0), t);
            player.rythmMode = true;
        }
        if (curTime >= endTime)
        {
            line.gameObject.SetActive(false);
            player.rythmMode = false;
        }
    }
}
