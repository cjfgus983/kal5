using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    private float timer=0f;
    public float graTime1;
    float smoothness=0.02f;
    float duration = 2;
    Color myBlue= new(16, 111, 181);
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        timer +=Time.deltaTime;
        if (timer >= graTime1)
        {
            graTime1 = 300;
            StartCoroutine(LerpColor());
        }
    }
    IEnumerator LerpColor()
    {
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            cam.backgroundColor = Color.Lerp(Color.black, Color.cyan, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        cam.backgroundColor = Color.black;
    }
}
