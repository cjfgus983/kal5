using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BulletStarter : MonoBehaviour
{
    double currentTime = 0d;
    public int bpm = 0;

    public Transform[] spawnPoints;//��ֹ� ��ȯ ��ġ
    public AudioSource bgm;

    public GameObject dice;

    public GameObject player;

    public ObjectManager objectManager; //������Ʈ Ǯ�� cs����

    //������Ʈ Ǯ�� �ؽ�Ʈ ����
    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;

    public float spawnDelay = 0;

	private void Awake()
	{
        spawnList = new List<Spawn>();
        ReadSpawnFile();
    }
    void ReadSpawnFile()
    {
        // 1. ���� �ʱ�ȭ 
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        // 2. ������ ���� �б�
        TextAsset textFile = Resources.Load("stage0") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text); //���� ����

        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            Debug.Log(line);
            if (line == null)
            {
                break;
            }

            Spawn spawnData = new Spawn(); //����ü �ϳ� ����
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.point = int.Parse(line.Split(',')[1]);
            spawnList.Add(spawnData);
        }

        // 3.�ؽ�Ʈ ���� �ݱ�
        stringReader.Close();
    }
    // Update is called once per frame
    void Update()
    {
        if (bgm.enabled == true)
        {
            currentTime += Time.deltaTime;

			//         if (currentTime >= spawnDelay && !spawnEnd)
			//{
			//             Spawn_bullet();
			//             currentTime = 0;
			//         }

			if (currentTime >= 60d / bpm)
			{
				Spawn_bullet();
				currentTime = 0;
			}
		}
    }



    void Spawn_bullet ()
	{
        int bulletPoint = spawnList[spawnIndex].point;

        GameObject bullet = objectManager.MakeObj("dice");
        bullet.transform.position = spawnPoints[bulletPoint].transform.position;
        //bullet.transform.rotation = spawnPoints[bulletPoint].transform.rotation;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();

        Vector3 dirVec = player.transform.position - spawnPoints[bulletPoint].transform.position;//�÷��̾� �ٶ󺸴� ����

        //rigid.velocity = dirVec.normalized * 5;
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        // #.������ �ε��� ����
        spawnIndex++;
        if(spawnIndex == spawnList.Count)
		{
            spawnEnd = true;
            return;
		}

        // #.���� ������ ������ ����
        bpm = (int)spawnList[spawnIndex].delay;
	}
}
