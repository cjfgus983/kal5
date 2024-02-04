using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class BorderPattern : PatternData
{
    public float lossVolume;
    public float patDur;
    private float timer = 0f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Expansion());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer + 0.5f >= patDur)
        {
            StartCoroutine(Contraction());
        }
    }

    IEnumerator Expansion()
    {
        for (int i=0;i<10;i++)
        {
            transform.localScale = new Vector3(transform.localScale.x - lossVolume/10f,
                                             transform.localScale.y - lossVolume/10f,
                                             transform.localScale.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Contraction()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x + lossVolume / 10f,
                                             transform.localScale.y + lossVolume / 10f,
                                             transform.localScale.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
