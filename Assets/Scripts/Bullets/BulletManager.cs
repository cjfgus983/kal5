using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class BulletManager : MonoBehaviour
{
    public List<GameObject> bulletList = new List<GameObject>();

    public GameObject bullet;
    public uint bulletQuantity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = bulletList.Count - 1; i > -1; i--)
        {
            if (bulletList[i] == null)
            {
                bulletList.RemoveAt(i);
                continue;
            }
        }

        for (int i = transform.childCount - 1; i > -1; i--)
        {
            if (!bulletList.Contains(transform.GetChild(i).gameObject))
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }

    public void CreateBullet()
    {
        for (int i = 0; i < bulletQuantity; i++)
        {
            bulletList.Add(Instantiate(bullet, this.transform));
        }
    }
}
