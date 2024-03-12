using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
	public AudioSource backgroundMusic;

	public bool isLobby;

    public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		if (backgroundMusic != null)
        {
			backgroundMusic.Pause();
		}
		transform.gameObject.SetActive(false);

	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		if (backgroundMusic != null)
		{
			backgroundMusic.UnPause();
		}
		transform.gameObject.SetActive(true);
	}

	public void Home()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Lobby");
	}

}
