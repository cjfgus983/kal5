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
    float vertical;
    float horizontal;
    public float counterCooltime;

    public BoxCollider2D box;
    public BoxCollider2D border;

    // Start is called before the first frame update
    void Start()
    {
        isCounter = false;
        canCounter = true;
        canHit = true;
        counterHit = false;
        canMove = true;
        vertical = 0;
        horizontal = 0;
        border = GameObject.Find("Border").GetComponent<BoxCollider2D>();
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
        Vector3 inputkey = new Vector2(horizontal, vertical);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (transform.position.y >= border.size.y / 2 - 0.4f - this.gameObject.transform.localScale.y / 2 && vertical > 0 || transform.position.y <= -1 * border.size.y / 2  + 0.4f + this.gameObject.transform.localScale.y / 2 && vertical < 0)
        {
            vertical = 0;
        }

        if (transform.position.x >= border.size.x / 2 - 0.4f - this.gameObject.transform.localScale.x / 2 && horizontal > 0 || transform.position.x <= -1 * border.size.x / 2 + 0.4f + this.gameObject.transform.localScale.x / 2 && horizontal < 0)
        {
            horizontal = 0;
        }

        transform.position += inputkey.normalized * moveSpeed * Time.deltaTime;
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
                Debug.LogError("Counter");
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
            StartCoroutine(CounterFail(counterCooltime));
        }
    }

    IEnumerator CounterFail(float cooltime)
    {
        yield return new WaitForSeconds(cooltime);
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
