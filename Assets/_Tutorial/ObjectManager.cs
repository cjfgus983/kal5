using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	public GameObject dicePrefab;//프리펩 담을 변수

	GameObject[] diceObject;//미리 생성한 게임 내 오브젝트
	GameObject[] targetPool;//소환할 오브젝트가 2개 이상일 때 편하게 MakeObj함수에서 사용하려고 만든거 난 필요없지만 추후 필요

    void Awake()
	{
		//한 화면에서 등장할 오브젝트 개수 대충 40개
		diceObject = new GameObject[40];
		Generate();
	}
	void Generate()
	{
		for(int i=0;i< diceObject.Length;i++)
		{
			diceObject[i] = Instantiate(dicePrefab); //인자하나만넣고 일단 그냥 만듦
			diceObject[i].SetActive(false); //일단 처음엔 비활성화
		}
	}
	public GameObject MakeObj(string type)
	{

		switch(type)
		{
			case "dice":
				targetPool = diceObject;
				break;
		}

		for(int i=0; i<targetPool.Length;i++)//for문이지만 결국 하나만 return됨
		{
			if(!targetPool[i].activeSelf)
			{
				targetPool[i].SetActive(true);
				return targetPool[i];
			}
		}
		return null;
	}
}
