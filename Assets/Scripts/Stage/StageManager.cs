using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageManager : MonoBehaviour
{
    public GameObject pm;
    public GameObject player;
    public GameObject gameOverUI;

    public string stageName;

    public AudioSource backgroundSound;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StageStart());
        pm.GetComponent<PatternManager>().PatternStart();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    void StartMusic()
    {
        backgroundSound.enabled = true;
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

    public void Retry()
    {
        SceneManager.LoadScene(stageName);
    }
}
