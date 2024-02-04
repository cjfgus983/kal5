using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : PatternData
{
    public Vector2 bulletDirect;
    public float bulletSpeed;
    public GameObject player;
    public bool aimPlayer;
    public bool isShotGun;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        if (isShotGun)
            ShotgunAimtoPlayer();
        else if (aimPlayer)
            AimtoPlayer();
        else
            AimDecision();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (aimPlayer)
            ShotgunAimtoPlayer();
    }
    void ShotgunAimtoPlayer()
    {
        transform.LookAt(player.transform);
    }

    void AimtoPlayer()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rigid.AddForce(dir*bulletSpeed, ForceMode2D.Impulse);
    }

    void AimDecision()
    {
        rigid.AddForce(Vector2.right * bulletSpeed*bulletDirect.x, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.up * bulletSpeed* bulletDirect.y, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this);
        }
    }
}
