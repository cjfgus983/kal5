using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{


    [SerializeField]
    private Slider hpBar;

    public float maxHP = 100;
    public float curHP = 100;

    public float getDamage = 0.1f;

    public GameObject player;

	private void Awake()
	{
        //player.GetComponent<Player>();
    }
	void Start()
    {
        hpBar.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
		if (player.GetComponent<Player>().getDamage == true)
		{
			curHP -= getDamage;

		}
		HandleHP();
    }

    void HandleHP()
	{
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHP / (float)maxHP, Time.deltaTime * 10);
    }
}
