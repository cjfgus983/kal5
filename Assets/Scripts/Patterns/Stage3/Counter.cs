using UnityEngine;

public class Counter : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController player;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.isCounter)
            {
                
                ReverseMove();
            }
        }
    }
    void ReverseMove()
    {
        gameObject.SetActive(false);
    }
}
