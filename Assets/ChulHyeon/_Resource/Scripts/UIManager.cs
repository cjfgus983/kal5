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

    void Start()
    {
        initialPanel.SetActive(true);
        Time.timeScale = 0f;
        backgroundMusic.Pause();

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
	}

}
