using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueBullet : PatternData
{

    //public PlayerManager playerManager; // 플레이어
    public GameObject player;

    public float speed = 5f;
    // Start is called before the first frame update
    protected override void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("find로 찾음");
        }

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            Vector3 dirVec = (player.transform.position - transform.position).normalized; // 플레이어 바라보는 방향
            rigid.velocity = dirVec * speed;  // 플레이어 쪽으로 이동
        }
        else
        {
            Debug.LogWarning("플레이어가 할당되지 않았습니다!");
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
