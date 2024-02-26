using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class explain : MonoBehaviour
{
    [SerializeField] GameObject explainMenu;

	public void ClickExplain()
	{
		explainMenu.SetActive(true);

	}

	public int currentPage = 1;
	public int totalPage = 2;
	public Button btnPrev;
	public Button btnNext;

	private void Start()
	{
		this.btnPrev.onClick.AddListener(() =>
		{
			this.PrevPage();
		});
        this.btnNext.onClick.AddListener(() =>
        {
            this.NextPage();
        });
    }

    public void NextPage()
    {
        if (this.currentPage == this.totalPage)
        {
            return;
        }
        this.currentPage++;

        //Debug.LogFormat("currentPage: {0}, totalPage: {1}", this.currentPage, this.totalPage);

        //var startIndex = (this.currentPage - 1) * this.arrUIStageItems.Length;
        //var endIndex = startIndex + this.arrUIStageItems.Length;
        //Debug.LogFormat("{0} ~ {1}", startIndex, endIndex);

        //for (int i = 0; i < this.arrUIStageItems.Length; i++)
        //{
        //    var uiStageItem = this.arrUIStageItems[i];
        //    uiStageItem.txtStageNo.text = (startIndex + i + 1).ToString();
        //}

        if (this.currentPage == this.totalPage)
        {
            this.btnNext.gameObject.SetActive(false);
        }
        else
        {
            this.btnNext.gameObject.SetActive(true);
        }
        this.btnPrev.gameObject.SetActive(true);
    }

    public void PrevPage()
    {
        if (this.currentPage == 1)
        {
            return;
        }
        this.currentPage--;
        //var startIndex = (this.currentPage - 1) * this.arrUIStageItems.Length;
        //var endIndex = startIndex + this.arrUIStageItems.Length;
        //Debug.LogFormat("{0} ~ {1}", startIndex, endIndex);
        //for (int i = 0; i < this.arrUIStageItems.Length; i++)
        //{
        //    var uiStageItem = this.arrUIStageItems[i];
        //    uiStageItem.txtStageNo.text = (startIndex + i + 1).ToString();
        //}
        if (this.currentPage == 1)
        {
            this.btnPrev.gameObject.SetActive(false);
        }
        else
        {
            this.btnPrev.gameObject.SetActive(true);
        }
        this.btnNext.gameObject.SetActive(true);
    }

}
