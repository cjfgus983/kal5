using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueBullet : PatternData
{

    //public PlayerManager playerManager; // �÷��̾�
    public GameObject player;

    public float speedMultiplier = 20f;

    Vector3 dirVec;
    // Start is called before the first frame update
    protected override void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("find�� ã��");
        }

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            Vector3 dirVec = (player.transform.position - transform.position).normalized; // �÷��̾� �ٶ󺸴� ����
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // �÷��̾���� �Ÿ�
            float speed = speedMultiplier / distanceToPlayer; // �Ÿ��� ���� �ӵ� ����
            rigid.velocity = dirVec * speed;
        }
        else
        {
            Debug.LogWarning("�÷��̾ �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
