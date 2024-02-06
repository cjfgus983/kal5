using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedBullet : PatternData
{

    //public PlayerManager playerManager; // �÷��̾�
    public GameObject player;
    public GameObject yellowBulletPrefab; // ��� �Ѿ� ������

    public float speed = 20f;
    Rigidbody2D rigid;
    Vector3 lastVelocity;


    // Start is called before the first frame update
    protected override void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("find�� ã��");
        }

        //Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            Vector3 dirVec = (player.transform.position - transform.position).normalized; // �÷��̾� �ٶ󺸴� ����
            rigid.velocity = dirVec * speed;
            //transform.position += dirVec * speed;  // �÷��̾� ������ �̵�
        }
        else
        {
            Debug.LogWarning("�÷��̾ �Ҵ���� �ʾҽ��ϴ�!");
        }
       

    }

    // Update is called once per frame
    protected override void Update()
    {
        lastVelocity = rigid.velocity;

        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude; //�ӵ��� ũ�⸸ �޾ƿ�
        var dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rigid.velocity = dir * Mathf.Max(speed, 0f);

        // ���� ������Ʈ ����
        Destroy(gameObject);

        // ���ο� ������ ���� �� ��ġ ����
        GameObject newPrefab = Instantiate(yellowBulletPrefab, transform.position, Quaternion.identity);

        // �ݻ� ������ �����ϱ� ���� ���ο� �����鿡 �ݻ�� ������ ����
        newPrefab.GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

}