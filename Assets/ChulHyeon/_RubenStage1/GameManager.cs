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
    //double currentTime = 0d;
    public GameObject gameOverSet;
    public GameObject player;

    //오브젝트 풀링을 위한 오브젝트

    
    void Update()
    {

        if(player.GetComponent<PlayerController>().hp<=0)
		{
            GameOver();

        }
    }


    public void GameOver()
	{
        gameOverSet.SetActive(true);
        Time.timeScale = 0f;
        GameStop();
    }
    void GameStop()
	{
        isGenerate = false;
    }

    void GameRetry()
	{
        SceneManager.LoadScene("Stage3");
	}
}
