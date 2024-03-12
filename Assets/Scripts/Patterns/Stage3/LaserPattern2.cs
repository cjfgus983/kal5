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
    public List<SpriteRenderer> squareColor = new List<SpriteRenderer>();
    Color colorA = new Color(255, 0, 0, 0.235f), colorB = new Color(255, 0, 0, 1f);
    public List<GameObject> setFalseChild = new List<GameObject>();
    public List<GameObject> setTrueChild = new List<GameObject>();
    private bool isAiming = true;
    Vector3 targetPosition;
    GameObject player;
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
            targetPosition = player.transform.position;
            child1.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - child1.position);
            child2.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - child2.position);
            child3.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - child3.position);
            StartCoroutine(Gradation());
            aimTimer += Time.deltaTime;
            if (aimTimer >= aimDuration)
            {
                isAiming = false;
                StartCoroutine(FireBullet());
            }
        }
    }
    IEnumerator Gradation()
    {
        for (int i=0;i<squareColor.Count;i++)
            squareColor[i].color = Color.Lerp(colorA, colorB, aimTimer / aimDuration);
        yield return null;
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
