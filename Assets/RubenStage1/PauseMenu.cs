using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    //public GameObject backGround;
    public AudioSource bgm;

    void Start()
    {
        pauseMenu.SetActive(false);
        //WaitMusic bgmScrpit = backGround.GetComponent<WaitMusic>();
        //AudioSource bgm = bgmScrpit.bgm;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
	{
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        bgm.Pause();

    }
    public void ResumeGame()
	{
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        bgm.Play();
    }

    public void GoMain()
	{
        SceneManager.LoadScene("MainPage");
    }
}
