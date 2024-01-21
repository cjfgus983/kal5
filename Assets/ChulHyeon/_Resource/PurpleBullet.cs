using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PurpleBullet : PatternData
{

    //public PlayerManager playerManager; // 플레이어
    public GameObject player;

    Animator animator;
    Rigidbody2D rigid;
    public GameObject prefabToShoot; // 발사할 프리팹

    public float speed = 5f;
    public float rotationSpeed = 300f; // 회전 속도

    // 이동을 멈추고 제자리에 머무를 시간
    public float stopAndStayTime = 2f; //2초뒤에 멈춤
    private bool Moving = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("find로 찾음");
        }

        if (player != null)
        {
            Vector3 dirVec = (player.transform.position - transform.position).normalized; // 플레이어 바라보는 방향
            rigid.velocity = dirVec * speed;  // 플레이어 쪽으로 이동
        }
        else
        {
            Debug.LogWarning("플레이어가 할당되지 않았습니다!");
        }
        StartCoroutine(StopMovingAfterTime());
    }

    // Update is called once per frame
    protected override void Update()
    {
        //base.Update();
        if (!Moving)
        {
            animator.enabled = true;
            //rigid.rotation = 0;
            transform.Rotate(Vector3.forward, 0 * Time.deltaTime);
            rigid.angularVelocity = 0;
        }
        else
		{
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator StopMovingAfterTime()
    {
        yield return new WaitForSeconds(stopAndStayTime);

        // 이동을 멈추고 제자리에 머무릅니다.
        rigid.velocity = Vector2.zero;
        Moving = false;
        yield return new WaitForSeconds(2f);
        ShootPrefabs();
        Destroy(gameObject);
    }

    void ShootPrefabs()
    {
        // 상
        Instantiate(prefabToShoot, transform.position, transform.rotation)
            .GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        // 하
        Instantiate(prefabToShoot, transform.position, transform.rotation * Quaternion.Euler(0, 0, 180))
            .GetComponent<Rigidbody2D>().velocity = -transform.up * speed;

        // 좌
        Instantiate(prefabToShoot, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90))
            .GetComponent<Rigidbody2D>().velocity = -transform.right * speed;

        // 우
        Instantiate(prefabToShoot, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90))
            .GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}
