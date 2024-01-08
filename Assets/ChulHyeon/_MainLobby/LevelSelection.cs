using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public bool unlocked;
	Image image;


	private void Start()
	{
		image = this.GetComponent<Image>();
	}
	private void Update()
	{
		UpdateLevelImage();
	}

	private void UpdateLevelImage()
	{
		if(!unlocked)//아직 안열림
		{
			image.color = new Color(0.5f, 0.5f, 0.5f, 1);
		}
		else//열림
		{
			image.color = new Color(1,1,1,1);
		}
	}

	public void PressSelection(string _LevelName)
	{
		if(unlocked)
		{
			SceneManager.LoadScene(_LevelName);
		}
	}
}
