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
    double currentTime = 0d;
    public GameObject gameOverSet;
    public GameObject player;
    public AudioSource bgm;

    //������Ʈ Ǯ���� ���� ������Ʈ

    
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
		//���� ��ȯ ��� (�纥 ���� ���ǥ��)
		if (isGenerate)
		{
            if(SceneManager.GetActiveScene().name == "Ruben1")
			{
                int ranPoint = Random.Range(0, 7);
                Instantiate(warnObject, spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);//���� ��ȯ ���
            }


		}

		//������Ʈ Ǯ��
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
