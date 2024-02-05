using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPattern2 : PatternData
{
    private float aimTimer=0f;
    public float aimDuration;
    public float bulletTiming;
    public Transform child1;
    public Transform child2;
    public Transform child3;
    public List<GameObject> setFalseChild = new List<GameObject>();
    public List<GameObject> setTrueChild = new List<GameObject>();
    private bool isAiming = true;
    public GameObject player;
    // Start is called before the first frame update
    protected override void Start()
    {
        player = GameObject.Find("Player");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (isAiming)
        {
            child1.LookAt(player.transform);
            child2.LookAt(player.transform);
            child3.LookAt(player.transform);
            child1.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            child2.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            child3.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            aimTimer += Time.deltaTime;
            if (aimTimer >= aimDuration)
            {
                isAiming = false;
                StartCoroutine(FireBullet());
            }
        }
    }
    IEnumerator FireBullet()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < setFalseChild.Count; i++)
        {
            setFalseChild[i].SetActive(false);
        }
        yield return new WaitForSeconds(bulletTiming - 0.5f);
        for (int i = 0; i < setTrueChild.Count; i++)
        {
            setTrueChild[i].SetActive(true);
        }
    }
}
