using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject initialPanel; // UI 패널을 가리키는 변수
    public AudioSource backgroundMusic;

    public GameObject pauseMenu;
    public GameObject pauseButton;

    public GameObject dontDetroy;

	private void Awake()
	{
        dontDetroy = GameObject.Find("DontDestroy");
    }

	void Start()
    {
        if (dontDetroy.GetComponent<DontDestroy>().prevScene == "Lobby") // 로비에서 왔다면
		{
            initialPanel.SetActive(true);
            Time.timeScale = 0f;
            backgroundMusic.Pause();
        }

    }

	private void Update()
	{
		if(initialPanel.activeSelf == false)
		{
            Time.timeScale = 1f;
            backgroundMusic.UnPause();
            gameObject.SetActive(false);
        }

        if (pauseMenu.activeSelf == true)
		{
            pauseButton.SetActive(false);
		}
        else
		{
            pauseButton.SetActive(true);
        }

        if(initialPanel.activeSelf == true)
		{
            Debug.Log("hello");
            pauseMenu.SetActive(false);
		}
	}

}
