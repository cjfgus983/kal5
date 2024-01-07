using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BulletStarter : MonoBehaviour
{
    double currentTime = 0d;
    public int bpm = 0;

    public Transform[] spawnPoints;//장애물 소환 위치
    public AudioSource bgm;

    public GameObject dice;

    public GameObject player;

    public ObjectManager objectManager; //오브젝트 풀링 cs파일

    //오브젝트 풀링 텍스트 관리
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
        // 1. 변수 초기화 
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        // 2. 리스폰 파일 읽기
        TextAsset textFile = Resources.Load("stage0") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text); //파일 열기

        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            Debug.Log(line);
            if (line == null)
            {
                break;
            }

            Spawn spawnData = new Spawn(); //구조체 하나 생성
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.point = int.Parse(line.Split(',')[1]);
            spawnList.Add(spawnData);
        }

        // 3.텍스트 파일 닫기
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

        Vector3 dirVec = player.transform.position - spawnPoints[bulletPoint].transform.position;//플레이어 바라보는 방향

        //rigid.velocity = dirVec.normalized * 5;
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        // #.리스폰 인덱스 증가
        spawnIndex++;
        if(spawnIndex == spawnList.Count)
		{
            spawnEnd = true;
            return;
		}

        // #.다음 리스폰 딜레이 갱신
        bpm = (int)spawnList[spawnIndex].delay;
	}
}
