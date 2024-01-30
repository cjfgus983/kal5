using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBullet : PatternData
{
    public GameObject bullet;
    int cnt = 0;
    public int maxShoot = 100;
    [Tooltip("1:up 2:down 3:left 4:right")]
    public int dir = 2;
    protected override void Start()
    {
        if (dir == 1)
            Fireup();
        else if (dir == 2)
            Firedown();
        else if (dir == 3)
            Fireleft();
        else if (dir == 4)
            Fireright();
    }

    protected override void Update()
    {
        
    }

    void Firedown()
	{
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rigid = newBullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 11 * cnt / maxShoot), -1); // 아래로 쏘는거
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        // 회전 적용
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg - 90;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        cnt++;
        if (cnt < maxShoot)
		{
            Invoke("Firedown", 0.15f);
		}
	}
    void Fireleft()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rigid = newBullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(-1, Mathf.Sin(Mathf.PI * 11 * cnt / maxShoot)); // 왼쪽
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        // 회전 적용
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg - 90;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        cnt++;
        if (cnt < maxShoot)
        {
            Invoke("Fireleft", 0.15f);
        }
    }
    void Fireright()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rigid = newBullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(1, Mathf.Sin(Mathf.PI * 11 * cnt / maxShoot)); // 왼쪽
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        // 회전 적용
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg - 90;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        cnt++;
        if (cnt < maxShoot)
        {
            Invoke("Fireright", 0.15f);
        }
    }
    void Fireup()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rigid = newBullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(1, Mathf.Sin(Mathf.PI * 11 * cnt / maxShoot)); // 왼쪽
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        // 회전 적용
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg - 90;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        cnt++;
        if (cnt < maxShoot)
        {
            Invoke("Fireup", 0.15f);
        }
    }
}
