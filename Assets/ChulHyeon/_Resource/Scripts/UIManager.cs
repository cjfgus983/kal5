using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject initialPanel; // UI �г��� ����Ű�� ����
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
        if (dontDetroy.GetComponent<DontDestroy>().prevScene == "Lobby") // �κ񿡼� �Դٸ�
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
