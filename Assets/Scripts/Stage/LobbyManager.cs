using System.Collections;
using System.Collections.Generic;

using UnityEditor.SearchService;

using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public List<string> sceneList = new List<string>();
    public List<GameObject> stageUI = new List<GameObject>();
    public List<GameObject> fieldList = new List<GameObject>();
    public GameObject player;
    public int stageNum;
    bool stageSelect;
    bool canSelect;
    // Start is called before the first frame update
    void Start()
    {
        stageSelect = false;
        canSelect = true;
        stageNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (stageSelect)
            {
                stageUI[stageNum - 1].SetActive(true);
                canSelect = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stageSelect)
            {
                stageUI[stageNum - 1].SetActive(false);
                canSelect = true;
            }
        }
        if (canSelect)
        {
            MoveInLobby();
        }
    }

    void MoveInLobby()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (stageNum > 0 && !stageSelect) stageNum--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (stageNum < sceneList.Count && !stageSelect) stageNum++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (stageNum != 0) stageSelect = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stageSelect = false;
        }

        if (stageSelect)
        {
            player.transform.position = fieldList[stageNum * 2 - 1].transform.position;

        } else
        {
            player.transform.position = fieldList[stageNum * 2].transform.position;
        }
    }
}
