using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public int nowStage;//���� �÷������� ��������
    public int clearStage = 0;//���ݱ��� Ŭ����� ��������
    public GameObject[] stages;


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainPage")
		{
            for (int i = 0; i <= clearStage; i++)
            {
                stages[i].GetComponent<LevelSelection>().unlocked = true;
            }
        }

        //Load
        //���߿� Ű��
        //clearStage = PlayerPrefs.GetInt("ClearStage");

	}

    public void GameClear(int nextStageIndex)
	{
        if (nextStageIndex > clearStage)
            clearStage = nextStageIndex;
        //Save
        PlayerPrefs.SetInt("ClearStage", clearStage);
    }
}
