using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : MonoBehaviour
{
    public bool isEasy;
    public bool isHard;

    private static StageData instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHard()
    {
        isEasy = false;
        isHard = true;
    }

    public void SelectEasy()
    {
        isEasy = true;
        isHard = false;
    }
}
