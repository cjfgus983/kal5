using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWarining : MonoBehaviour
{
    public GameObject obstacle;
    bool spawnObstacle;


    // Update is called once per frame
    void Update()
    {
		Invoke("DestroyAndSpawn", 1);
	}

    void DestroyAndSpawn()
    {
		Instantiate(obstacle, transform.position, transform.rotation);
		Destroy(this.gameObject);//���� ����
		//gameObject.SetActive(false);//�ڱ��ڽ� setactive false
	}
}
