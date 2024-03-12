using System.Collections;
using System.Collections.Generic;

using UnityEditor.SearchService;

using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public List<string> sceneList = new List<string>();
    public List<GameObject> musicList = new List<GameObject>();
    public GameObject startButton;
    public GameObject easyButton;
    public GameObject hardButton;

    public int stageNum;
    bool canSelect;
    // Start is called before the first frame update
    void Start()
    {
        canSelect = true;
        stageNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartButton();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canSelect = true;
            startButton.SetActive(true);
            easyButton.SetActive(false);
            hardButton.SetActive(false);
        }

        if (canSelect)
        {
            SelectInLobby();
        }

        ChangeMusic(stageNum);
    }

    void SelectInLobby()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stageNum--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            stageNum++;
        }

        if (stageNum < 0)
        {
            stageNum = sceneList.Count - 1;
        }

        if (stageNum > sceneList.Count - 1)
        {
            stageNum = 0;
        }

    }

    void SelectDifficulty()
    {

    }

    void ChangeMusic(int num)
    {
        for (int i = 0; i < musicList.Count; i++)
        {
            
        }
    }

    public void StartButton()
    {
        canSelect = false;
        startButton.SetActive(false);
        easyButton.SetActive(true);
        hardButton.SetActive(true);
    }
}
