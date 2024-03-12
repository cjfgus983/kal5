using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider progressBar;

    private void Update()
    {
        if (musicSource.isPlaying)
        {
            progressBar.value = musicSource.time / musicSource.clip.length;
        } else if (musicSource.enabled == true && musicSource.isPlaying == false)
        {
            progressBar.value = 1;
        }
    }
}
