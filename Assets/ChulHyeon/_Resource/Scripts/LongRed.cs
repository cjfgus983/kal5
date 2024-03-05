using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRed : MonoBehaviour
{

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = transform.up * 3;
    }
}
