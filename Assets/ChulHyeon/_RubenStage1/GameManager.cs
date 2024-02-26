using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   //루벤전용
    public GameObject warnObject;
    //공통
    public bool isGenerate = true;
    public Transform[] spawnPoints;//장애물 소환 위치
    public int bpm = 0;
    double currentTime = 0d;
    public GameObject gameOverSet;
    public GameObject player;
    public AudioSource bgm;

    //오브젝트 풀링을 위한 오브젝트

    
    void Update()
    {
        if (bgm.enabled == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 60d / bpm)
            {
                SpawnWarn();
                currentTime -= 60d / bpm;
            }
        }

        if(player.GetComponent<PlayerController>().hp<=0)
		{
            GameOver();

        }
    }

    void SpawnWarn()
	{
		//기존 소환 방법 (루벤 한정 경고표시)
		if (isGenerate)
		{
            if(SceneManager.GetActiveScene().name == "Ruben1")
			{
                int ranPoint = Random.Range(0, 7);
                Instantiate(warnObject, spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);//기존 소환 방법
            }


		}

		//오브젝트 풀링
		//if (isGenerate)
		//{
		//	int ranPoint = Random.Range(0, 7);
		//	GameObject warn = objectManager.MakeObj("warningObject");
		//	warn.transform.position = spawnPoints[ranPoint].position;
		//}
	}

    public void GameOver()
	{
        gameOverSet.SetActive(true);
        Time.timeScale = 0f;
        GameStop();
    }
    void GameStop()
	{
        bgm.enabled = false;
        isGenerate = false;
    }

    void GameRetry()
	{
        SceneManager.LoadScene(1);
	}
}
