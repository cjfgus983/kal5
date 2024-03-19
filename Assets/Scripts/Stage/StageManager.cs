using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{
    public GameObject pm;
    public GameObject player;
    public GameObject gameOverUI;
    public GameObject StageData;

    public string stageName;

    public GameObject progressBar;
    public bool isClear;
    public AudioSource backgroundSound;

    public GameObject ClearMenu;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StageStart());
        pm.GetComponent<PatternManager>().PatternStart();
        isClear = false;
        StageData = GameObject.Find("StageData");
        if (StageData.GetComponent<StageData>().isHard)
        {
            player.GetComponent<PlayerController>().hp = 3;
        }
        if (StageData.GetComponent<StageData>().isEasy)
        {
            player.GetComponent<PlayerController>().hp = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        ProgressBar();
    }

    void StartMusic()
    {
        backgroundSound.enabled = true;
        StartCoroutine(ClearStage(backgroundSound.clip.length));
    }

    IEnumerator StageStart()
    {
        pm.GetComponent<PatternManager>().PatternStart();
        yield return new WaitForSeconds(3.0f);
        StartMusic();
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
        }
    }

    void GameOver()
    {
        if (player.GetComponent<PlayerController>().hp <= 0)
        {
            gameOverUI.SetActive(true);
            player.GetComponent<PlayerController>().canMove = false;
            backgroundSound.enabled = false;
            pm.SetActive(false);
        }
    }
    void ProgressBar()
    {
        if (!isClear)
        {
            progressBar.GetComponent<Slider>().value = backgroundSound.time / backgroundSound.clip.length;
        }
        else
        {
            progressBar.GetComponent<Slider>().value = 1;

        }
    }

    IEnumerator ClearStage(float music)
    {
        yield return new WaitForSeconds(music);
        isClear = true;
        yield return new WaitForSeconds(3.0f);
        ClearMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void Retry()
    {
        SceneManager.LoadScene(stageName);
    }

    public void GoLobby()
	{
        SceneManager.LoadScene("Lobby");
    }
}
