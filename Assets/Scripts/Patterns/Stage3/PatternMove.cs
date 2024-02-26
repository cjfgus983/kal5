using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMove : MonoBehaviour
{
    public float xMove;
    public float yMove;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainMove();
    }

    // Update is called once per frame
    void mainMove()
    {
        rigid.AddForce(Vector2.right * xMove, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.up * yMove, ForceMode2D.Impulse);
    }
}
