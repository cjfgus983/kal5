using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public GameObject LobbyManager;

    public GameObject stageData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stageData == null)
		{
            stageData = GameObject.Find("StageData");

		}
    }

    public void OnStartButtonClick()
    {
        LobbyManager.GetComponent<LobbyManager>().StartButton();
    }

    public void OnEasyButtonClick()
    {
        stageData.GetComponent<StageData>().SelectEasy();
        SceneManager.LoadScene(LobbyManager.GetComponent<LobbyManager>().sceneList[LobbyManager.GetComponent<LobbyManager>().stageNum]);
    }

    public void OnHardButtonClick()
    {
        stageData.GetComponent<StageData>().SelectHard();
        SceneManager.LoadScene(LobbyManager.GetComponent<LobbyManager>().sceneList[LobbyManager.GetComponent<LobbyManager>().stageNum]);
    }

    public void OnLeftArrowClick()
    {
        LobbyManager.GetComponent<LobbyManager>().stageNum--;
    }

    public void OnRightArrowClick()
    {
        LobbyManager.GetComponent<LobbyManager>().stageNum++;
    }

    public void Exit()
	{
        Application.Quit();
    }
}
