using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PurpleBullet : PatternData
{

    //public PlayerManager playerManager; // �÷��̾�
    public GameObject player;

    Animator animator;
    Rigidbody2D rigid;
    public GameObject prefabToShoot; // �߻��� ������

    public float speed = 5f;
    public float rotationSpeed = 300f; // ȸ�� �ӵ�

    // �̵��� ���߰� ���ڸ��� �ӹ��� �ð�
    public float stopAndStayTime = 2f; //2�ʵڿ� ����
    private bool Moving = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (player == null)
        {
            player = GameObject.Find("Player");
            Debug.Log("find�� ã��");
        }

        if (player != null)
        {
            Vector3 dirVec = (player.transform.position - transform.position).normalized; // �÷��̾� �ٶ󺸴� ����
            rigid.velocity = dirVec * speed;  // �÷��̾� ������ �̵�
        }
        else
        {
            Debug.LogWarning("�÷��̾ �Ҵ���� �ʾҽ��ϴ�!");
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

        // �̵��� ���߰� ���ڸ��� �ӹ����ϴ�.
        rigid.velocity = Vector2.zero;
        Moving = false;
        yield return new WaitForSeconds(2f);
        ShootPrefabs();
        Destroy(gameObject);
    }

    void ShootPrefabs()
    {
        // ��
        Instantiate(prefabToShoot, transform.position, transform.rotation)
            .GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        // ��
        Instantiate(prefabToShoot, transform.position, transform.rotation * Quaternion.Euler(0, 0, 180))
            .GetComponent<Rigidbody2D>().velocity = -transform.up * speed;

        // ��
        Instantiate(prefabToShoot, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90))
            .GetComponent<Rigidbody2D>().velocity = -transform.right * speed;

        // ��
        Instantiate(prefabToShoot, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90))
            .GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}
