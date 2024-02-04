using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int hp;
    bool canCounter;
    public bool isCounter;
    bool canHit;
    bool counterHit;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        isCounter = false;
        canCounter = true;
        canHit = true;
        counterHit = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
        
        Counter();
        if (isCounter)
        {
            if (counterHit)
            {
                Debug.Log("Counter");
                canCounter = true;
                counterHit = false;
            } 
        } 
        else
        {
            if (counterHit)
            {
                counterHit = false;
                hp--;
            }
        }
    }

    void Move()
    {
        Vector3 inputkey = new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical")).normalized * moveSpeed * Time.deltaTime;
        transform.position += inputkey;
    }

    void Damage()
    {
        if (canHit)
        {
            hp--;
            canHit = false;
            StartCoroutine(Hit());
        }
    }

    void Counter()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canCounter)
            {
                isCounter = true;
                canCounter = false;
                canMove = false;
                StartCoroutine(CounterDecision());
            }
        }

        
    }

    IEnumerator CounterDecision()
    {
        yield return new WaitForSeconds(0.2f);
        isCounter = false;
        canMove = true;
        if (!counterHit)
        {
            StartCoroutine(CounterFail());
        }
    }

    IEnumerator CounterFail()
    {
        yield return new WaitForSeconds(1.0f);
        canCounter = true;
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(1.0f);
        canHit = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pattern" || collision.gameObject.tag == "bullet")
        {
            Damage();
        }

        if (collision.gameObject.tag == "Counter")
        {
            counterHit = true;
        }
    }
}
