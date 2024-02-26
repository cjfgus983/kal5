using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BorderPattern2 : PatternData
{
    public float lossVolume;
    public float gainVolume;
    float xSize, ySize;
    bool setZero = true;
    Vector2 borderNorm;
    private float timer = 0f;
    GameObject player;
    public BoxCollider2D border;
    public List<float> lossTiming = new List<float>();
    public List<float> gainTiming = new List<float>();
    int i = 0;
    int j = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        border = GameObject.Find("Border").GetComponent<BoxCollider2D>();
        borderNorm = border.size;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (i<lossTiming.Count && timer + 0.5f >= lossTiming[i])
        {
            StartCoroutine(Contraction());
            player.GetComponent<PlayerController>().canMove = false;
            i++;
        }
        else if (i>=lossTiming.Count && setZero)
        {
            setZero = false;
            player.transform.position = new Vector3(0, 0, 0);
        }
        if (j < gainTiming.Count && timer + 0.5f >= gainTiming[j])
        {
            StartCoroutine(Expansion());
            player.GetComponent<PlayerController>().canMove = true;
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
            xSize = transform.localScale.x > border.size.x ? border.size.x : transform.localScale.x;
            ySize = transform.localScale.y > border.size.y ? border.size.y : transform.localScale.y;
            border.size = new Vector2(xSize, ySize);
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
            xSize = transform.localScale.x > borderNorm.x ? borderNorm.x : transform.localScale.x;
            ySize = transform.localScale.y > borderNorm.y ? borderNorm.y : transform.localScale.y;
            border.size = new Vector2(xSize, ySize);
            yield return new WaitForSeconds(0.05f);
        }
    }
}

