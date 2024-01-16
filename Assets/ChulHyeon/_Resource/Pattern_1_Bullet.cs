using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pattern_1_Bullet : PatternData
{

    public GameObject player; // �÷��̾�
    private float currentTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        Vector3 dirVec = player.transform.position - transform.position;//�÷��̾� �ٶ󺸴� ����
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    protected override void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= patStartTime)
		{
            gameObject.SetActive(true);
            Debug.Log("�ð� ��");
        }
    }
}
