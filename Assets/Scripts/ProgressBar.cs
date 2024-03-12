using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider progressBar;

    public GameObject clearUI;

    private void Update()
    {
        progressBar.value = musicSource.time / musicSource.clip.length;
        if(progressBar.value == 1)
		{

            StartCoroutine(ClearUIOpen());
        }
    }
    IEnumerator ClearUIOpen()
	{
        yield return new WaitForSeconds(1f);
        clearUI.SetActive(true);
    }
}
