using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public WaitMusic bgm;
    public GameObject line;
    public GameObject player; 

    public float curTime = 0f;

    bool startAnim;
    public float startTime;
    public float endTime;
    void Start()
    {
        startAnim = false;
        StartCoroutine(StartLine());
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnim)
        {
            line.transform.localScale = Vector3.Lerp(line.transform.localScale, new Vector3(0.55f, 0.55f, 0),  3 * Time.deltaTime);
        }
    }

    IEnumerator StartLine()
    {
        yield return new WaitForSeconds(startTime);
        startAnim = true;
        player.GetComponent<Player>().rythmMode = true;
        yield return new WaitForSeconds(endTime - startTime);
        line.gameObject.SetActive(false);
        player.GetComponent<Player>().rythmMode = false;
        player.GetComponent<PlayerController>().canMove = true;
    }
}
