using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public int nowStage;//현재 플레이중인 스테이지
    public int clearStage = 0;//지금까지 클리어된 스테이지
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
        //나중에 키자
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
