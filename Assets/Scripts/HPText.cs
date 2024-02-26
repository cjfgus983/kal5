using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    public TextMeshProUGUI scriptText;
    float hp;
    PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        hp = player.hp;
    }
    private void Update()
    {
        hp = player.hp;
        scriptText.text = "X " + hp;
    }
}
