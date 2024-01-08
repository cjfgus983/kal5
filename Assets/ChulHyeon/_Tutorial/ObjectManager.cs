using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	public GameObject dicePrefab;//������ ���� ����

	GameObject[] diceObject;//�̸� ������ ���� �� ������Ʈ
	GameObject[] targetPool;//��ȯ�� ������Ʈ�� 2�� �̻��� �� ���ϰ� MakeObj�Լ����� ����Ϸ��� ����� �� �ʿ������ ���� �ʿ�

    void Awake()
	{
		//�� ȭ�鿡�� ������ ������Ʈ ���� ���� 40��
		diceObject = new GameObject[40];
		Generate();
	}
	void Generate()
	{
		for(int i=0;i< diceObject.Length;i++)
		{
			diceObject[i] = Instantiate(dicePrefab); //�����ϳ����ְ� �ϴ� �׳� ����
			diceObject[i].SetActive(false); //�ϴ� ó���� ��Ȱ��ȭ
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

		for(int i=0; i<targetPool.Length;i++)//for�������� �ᱹ �ϳ��� return��
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
