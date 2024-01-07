using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bpmrotate : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(bgm.enabled == true)
		{
            currentTime += Time.deltaTime;
            if (currentTime >= 60d / bpm)
            {
                transform.Rotate(0, 0, 45);
                currentTime -= 60d / bpm;
            }
        }
  //      currentTime += Time.deltaTime;
  //      if(currentTime >= 60d/bpm)
		//{
  //          transform.Rotate(0, 0, 45);
  //          currentTime -= 60d / bpm;
  //      }
    }
}
