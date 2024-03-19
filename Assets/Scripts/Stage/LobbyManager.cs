using System.Collections;
using System.Collections.Generic;

using UnityEngine.SearchService;

using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public List<string> sceneList = new List<string>();
    public List<AudioClip> bgmList = new List<AudioClip>();
    public GameObject musicList;
    public GameObject startButton;
    public GameObject easyButton;
    public GameObject hardButton;

    AudioSource audioSource;
    Vector3 targetPos;
    Vector3 pageStep;
    public LeanTweenType tweenType;
    public int stageNum;
    bool canSelect;
    // Start is called before the first frame update
    void Start()
    {
        canSelect = true;
        stageNum = 0;
        targetPos = new Vector3(1000, 0, 0);
        pageStep = new Vector3(1000, 0, 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmList[stageNum];
        audioSource.Play();
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

        if (audioSource.time > 0 && audioSource.time < 3 && audioSource.volume < 0.3f)
        {
            audioSource.volume += Time.deltaTime * 0.1f;
        }

        if (audioSource.time > 17.0f)
        {
            audioSource.volume -= Time.deltaTime * 0.1f;
        }

        if (audioSource.time > 20.0f)
        {
            audioSource.time = 0;
            
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

    void ChangeMusic()
    {
        musicList.GetComponent<RectTransform>().LeanMoveLocal(targetPos - pageStep * stageNum, 0.5f).setEase(tweenType);
        audioSource.clip = bgmList[stageNum];
        audioSource.volume = 0;
        audioSource.Play();
    }

    public void OnLeftArrowClick()
    {
        stageNum--;
        if (stageNum < 0)
        {
            stageNum = sceneList.Count - 1;
        }

        if (stageNum > sceneList.Count - 1)
        {
            stageNum = 0;
        }
        ChangeMusic();
    }

    public void OnRightArrowClick()
    {
        stageNum++;
        if (stageNum < 0)
        {
            stageNum = sceneList.Count - 1;
        }

        if (stageNum > sceneList.Count - 1)
        {
            stageNum = 0;
        }
        ChangeMusic();
    }

    public void StartButton()
    {
        canSelect = false;
        startButton.SetActive(false);
        easyButton.SetActive(true);
        hardButton.SetActive(true);
    }
}
