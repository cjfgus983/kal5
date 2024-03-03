using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public GameObject LobbyManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClick()
    {
        LobbyManager.GetComponent<LobbyManager>().StartButton();
    }

    public void OnEasyButtonClick()
    {
        SceneManager.LoadScene(LobbyManager.GetComponent<LobbyManager>().sceneList[LobbyManager.GetComponent<LobbyManager>().stageNum]);
    }

    public void OnHardButtonClick()
    {
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
}
