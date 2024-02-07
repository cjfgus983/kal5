using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPattern : MonoBehaviour
{
    int dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10)
        {
            dir = -1;
        } else if (transform.position.y < -10)
        {
            dir = 1;
        }
        this.transform.position += new Vector3(0, dir * 20 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerController>().isCounter)
            {
                dir = dir * -1;
            }
        }
    }
}
