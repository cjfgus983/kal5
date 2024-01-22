using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveObject", 2f);
    }
    void RemoveObject()
    {
        Destroy(gameObject);
    }
}
