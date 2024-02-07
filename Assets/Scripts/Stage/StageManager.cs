using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject pm;

    public AudioSource backgroundSound;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StageStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMusic()
    {
        backgroundSound.Play();
    }

    IEnumerator StageStart()
    {
        yield return new WaitForSeconds(3.0f);
        pm.GetComponent<PatternManager>().PatternStart();
        StartMusic();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
