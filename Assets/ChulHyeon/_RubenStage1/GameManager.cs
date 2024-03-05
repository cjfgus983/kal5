using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   //�纥����
    public GameObject warnObject;
    //����
    public bool isGenerate = true;
    public Transform[] spawnPoints;//��ֹ� ��ȯ ��ġ
    public int bpm = 0;
    //double currentTime = 0d;
    public GameObject gameOverSet;
    public GameObject player;

    //������Ʈ Ǯ���� ���� ������Ʈ

    
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
