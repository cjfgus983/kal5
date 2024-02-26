using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    GameObject player;
    PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            pc.Damage();
        }
    }
}
