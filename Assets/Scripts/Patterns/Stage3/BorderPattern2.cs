using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BorderPattern2 : PatternData
{
    public float lossVolume;
    public float gainVolume;
    private float timer = 0f;
    public List<float> lossTiming = new List<float>();
    public List<float> gainTiming = new List<float>();
    int i = 0;
    int j = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (i<lossTiming.Count && timer + 0.5f >= lossTiming[i])
        {
            StartCoroutine(Contraction());
            i++;
        }
        if (j < gainTiming.Count && timer + 0.5f >= gainTiming[j])
        {
            StartCoroutine(Expansion());
            j++;
        }
    }
    IEnumerator Contraction()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x - (lossVolume/lossTiming.Count) / 10f,
                                             transform.localScale.y - (lossVolume/lossTiming.Count) / 10f,
                                             transform.localScale.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Expansion()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x + (gainVolume/gainTiming.Count) / 10f,
                                             transform.localScale.y + (gainVolume/gainTiming.Count) / 10f,
                                             transform.localScale.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
}

