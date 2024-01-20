using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pattern_1_Bullet : PatternData
{

    //public PlayerManager playerManager; // �÷��̾�
    public GameObject player;

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
            Vector3 dirVec = player.transform.position - transform.position; // �÷��̾� �ٶ󺸴� ����
            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse); //
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
