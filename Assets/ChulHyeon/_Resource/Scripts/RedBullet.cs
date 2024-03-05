using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedBullet : PatternData
{

    //public PlayerManager playerManager; // 플레이어
    public GameObject player;
    public GameObject yellowBulletPrefab; // 노란 총알 프리팹

    public float speed = 5f;
    Rigidbody2D rigid;
    Vector3 lastVelocity;


    // Start is called before the first frame update
    protected override void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("find로 찾음");
        }

        //Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            // 플레이어를 바라보도록 방향 설정
            Vector3 dirVec = (player.transform.position - transform.position).normalized;

            // 설정된 방향으로 이동
            rigid.velocity = dirVec * speed;
        }
        else
        {
            Debug.LogWarning("플레이어가 할당되지 않았습니다!");
        }
        StartCoroutine(SetFalse());

    }

    // Update is called once per frame
    protected override void Update()
    {
        lastVelocity = rigid.velocity;

        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Border")
		{
            var speed = lastVelocity.magnitude; //속도의 크기만 받아옴
            var dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rigid.velocity = dir * Mathf.Max(speed, 0f);

            // 기존 오브젝트 삭제
            Destroy(gameObject);

            // 새로운 프리펩 생성 및 위치 설정
            GameObject newPrefab = Instantiate(yellowBulletPrefab, transform.position, Quaternion.identity);

            // 반사 방향을 유지하기 위해 새로운 프리펩에 반사된 방향을 설정
            newPrefab.GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

}
