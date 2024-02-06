using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public WaitMusic bgm;
    public GameObject line;
    public Player player; 

    public float curTime = 0f;

    void Start()
    {
        line.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime = bgm.curTime;
        if(curTime >= 69.46)
		{
            line.gameObject.SetActive(true);
            player.rythmMode = true;
        }
        if (curTime >= 82)
        {
            line.gameObject.SetActive(false);
            player.rythmMode = false;
        }
    }
}
