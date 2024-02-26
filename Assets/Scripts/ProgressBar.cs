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
        progressBar.value = musicSource.time / musicSource.clip.length;
    }
}
