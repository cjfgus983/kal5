using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPattern : PatternData
{
    public bool isVert;
    public GameObject player;
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    SpriteRenderer child2color;
    float a, t;
    public float aimDuration;
    public float bulletTiming;
    private float aimTimer=0f;
    private bool isAiming = true;
    Transform trans;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        trans = GetComponent<Transform>();
        child2color = child2.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        if (isVert)
            AimVert();
        else
            AimHoriz();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (isAiming)
        {
            if (isVert)
                AimVert();
            else
                AimHoriz();
            aimTimer += Time.deltaTime;
            if (aimTimer >= aimDuration)
            {
                isAiming = false;
                StartCoroutine(FireBullet());
            }
        }
    }

    void AimVert()
    {
        trans.position = new Vector2(trans.position.x,player.transform.position.y);
    }

    void AimHoriz()
    {
        trans.position = new Vector2(player.transform.position.x, trans.position.y);
    }

    IEnumerator FireBullet()
    {
        t = 255;
        for (a = 60; a < t; a++)
        {
            child2color.color = new Color(255, 0, 0, a / t);
            yield return new WaitForSeconds(aimDuration/195f);
        }
        yield return new WaitForSeconds(0.5f);
        child1.SetActive(false);
        child2.SetActive(false);
        yield return new WaitForSeconds(bulletTiming-0.5f);
        child3.SetActive(true);
    }
    
}
