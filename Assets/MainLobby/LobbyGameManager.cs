using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyGameManager : MonoBehaviour
{
    public bool checkRuben;
    public GameObject PanelRuben;

    void Start()
    {
		PanelRuben.SetActive(false);
	}

    public void ClickRuben()
    {
        if (checkRuben == false)
        {
            checkRuben = true;
            PanelRuben.SetActive(true);
        }
        else if (checkRuben == true)
        {
            checkRuben = false;
            PanelRuben.SetActive(false);
        }
    }

}
