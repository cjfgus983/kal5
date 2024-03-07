using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
	public AudioSource backgroundMusic;


	public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		backgroundMusic.Pause();
		transform.gameObject.SetActive(false);

	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		backgroundMusic.UnPause();
		transform.gameObject.SetActive(true);
	}

	public void Home(int sceneID)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneID);
	}
}
