using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    public Color[] colors;
    public GameObject imageContent;
    public float index = 0;
    float[] pos;
    private Button takeTheBtn;
    int btnNumber;

    void Update()
    {
        pos = new float[transform.childCount]; //자식 개수 받아와

        for (int i = 0; i < pos.Length; i++)
        {
            if (index == i) // 현재 인덱스에 따라
            {
                //Debug.LogWarning("Current Selected Level" + i);
                transform.GetChild(i).transform.gameObject.SetActive(true);
                imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                imageContent.transform.GetChild(i).GetComponent<Image>().color = colors[1];
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).transform.gameObject.SetActive(false);
                        imageContent.transform.GetChild(j).GetComponent<Image>().color = colors[0];
                        imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            imageContent.transform.GetChild(i).name = ".";
        }

    }
    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                index = i;
            }
        }
    }

    public void Prev()
	{
        if (index == 0)
            return;
		else
		{
            index--;
		}
	}
    public void Next()
    {
        if (index == transform.childCount -1)
		{
            Close();
		}
        else
        {
            index++;
        }
    }
    public void Close()
    {
        transform.parent.transform.gameObject.SetActive(false);
    }

    public void Explain()
	{
        transform.parent.transform.gameObject.SetActive(true);
        index = 0;
    }
}
