using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public float curTime = 0;
    public float limitTime= 3;
    public AudioSource bgm;

    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.enabled = false;
    }

	private void Update()
	{
        curTime += Time.deltaTime;
	}
}
