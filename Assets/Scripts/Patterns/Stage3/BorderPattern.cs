using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class BorderPattern : PatternData
{
    public float lossVolume;
    public float patDur;
    Vector2 borderNorm;
    float xSize,ySize;
    private float timer = 0f;
    GameObject player;
    public BoxCollider2D border;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player= GameObject.Find("Player");
        border = GameObject.Find("Border").GetComponent<BoxCollider2D>();
        borderNorm = border.size;
        StartCoroutine(Contraction());
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        player.GetComponent<PlayerController>().canMove = false;
        if (timer + 0.5f >= patDur)
        {
            StartCoroutine(Expansion());
            player.GetComponent<PlayerController>().canMove = true;
        }
    }

    IEnumerator Contraction()
    {
        
        for (int i=0;i<10;i++)
        {
            transform.localScale = new Vector3(transform.localScale.x - lossVolume/10f,
                                             transform.localScale.y - lossVolume/10f,
                                             transform.localScale.z);
            xSize =transform.localScale.x>border.size.x?border.size.x:transform.localScale.x;
            ySize = transform.localScale.y > border.size.y ? border.size.y : transform.localScale.y;
            border.size = new Vector2(xSize, ySize);
            yield return new WaitForSeconds(0.05f);
        }
        player.transform.position = new Vector3(0, 0, 0);
    }
    IEnumerator Expansion()
    {
        
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x + lossVolume / 10f,
                                             transform.localScale.y + lossVolume / 10f,
                                             transform.localScale.z);
            xSize = transform.localScale.x > borderNorm.x ? borderNorm.x : transform.localScale.x;
            ySize = transform.localScale.y > borderNorm.y ? borderNorm.y : transform.localScale.y;
            border.size = new Vector2(xSize, ySize);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
