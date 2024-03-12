using System.Collections;
using System.Collections.Generic;

using UnityEditor.SearchService;

using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public List<string> sceneList = new List<string>();
    public GameObject musicList;
    public GameObject startButton;
    public GameObject easyButton;
    public GameObject hardButton;

    public LeanTweenType tweenType;
    public Vector3 targetPos;
    Vector3 pageStep;
    public int stageNum;
    bool canSelect;
    // Start is called before the first frame update
    void Start()
    {
        canSelect = true;
        stageNum = 0;
        pageStep = new Vector3(1000, 0, 0);
        targetPos = new Vector3(1000, 0, 0);
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

        
    }

    void SelectInLobby()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeftArrowClick();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRightArrowClick();
        }

        

    }

    void SelectDifficulty()
    {

    }

    void ChangeMusic(int num)
    {
        if (stageNum < 0)
        {
            stageNum = sceneList.Count - 1;
        }

        if (stageNum > sceneList.Count - 1)
        {
            stageNum = 0;
        }
        targetPos = new Vector3(1000, 0, 0) - pageStep * stageNum;
        musicList.GetComponent<RectTransform>().LeanMoveLocal(targetPos, 0.5f).setEase(tweenType);
    }

    public void OnLeftArrowClick()
    {
        stageNum--;
        ChangeMusic(stageNum);
    }

    public void OnRightArrowClick()
    {
        stageNum++;
        ChangeMusic(stageNum);
    }

    public void StartButton()
    {
        canSelect = false;
        startButton.SetActive(false);
        easyButton.SetActive(true);
        hardButton.SetActive(true);
    }
}
