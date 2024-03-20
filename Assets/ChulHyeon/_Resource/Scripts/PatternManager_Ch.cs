using System.Collections;
using System.Collections.Generic;
using System.IO;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

public class PatternManager_Ch : PatternManager
{
    //PatternData pd;

    public TextAsset textFile;
    public TextAsset textFile2;

    void Awake()
	{
		// ������Ʈ Ǯ�� - ����
		patList.Clear();

		StringReader reader = new StringReader(textFile.text);
		StringReader reader2 = new StringReader(textFile2.text);

		while (true)
		{
			string line = reader.ReadLine();
			if (line == null)
			{
				break;
			}
			if (line.StartsWith("#"))
			{
				continue;
			}
			string[] parts = line.Split('/');
			if (parts.Length == 5)
			{
				float patStartTime = float.Parse(parts[0]);
				float posX = float.Parse(parts[1]);
				float posY = float.Parse(parts[2]);
				float patDuration = float.Parse(parts[3]);
				string prefabName = parts[4];

				// �� �κп� �ʿ��� ó���� �߰��ϼ���.
				Vector2 patPos = new Vector2(posX, posY);
				float patRot = 0f; // ���÷� 0���� ����. �ʿ信 ���� ����
				GameObject patternPrefab = Resources.Load<GameObject>(prefabName);
				GameObject go = Instantiate(patternPrefab, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
				go.GetComponent<PatternData>().patStartTime = patStartTime;
				go.GetComponent<PatternData>().patDuration = patDuration;
				go.GetComponent<PatternData>().patRot = patRot;
				// spawnData
				go.SetActive(false);
				patList.Add(go);
			}
			else if (parts.Length == 6)
			{
				float patStartTime = float.Parse(parts[0]);
				float posX = float.Parse(parts[1]);
				float posY = float.Parse(parts[2]);
				float patDuration = float.Parse(parts[3]);
				string prefabName = parts[4];
				float patRot = float.Parse(parts[5]);

				// �� �κп� �ʿ��� ó���� �߰��ϼ���.
				Vector2 patPos = new Vector2(posX, posY);
				GameObject patternPrefab = Resources.Load<GameObject>(prefabName);
				GameObject go = Instantiate(patternPrefab, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
				go.GetComponent<PatternData>().patStartTime = patStartTime;
				go.GetComponent<PatternData>().patDuration = patDuration;
				go.GetComponent<PatternData>().patRot = patRot;
				// spawnData
				go.SetActive(false);
				patList.Add(go);
			}
			//circle bullet��
			else if (parts.Length == 7)
			{
				float patStartTime = float.Parse(parts[0]);
				float posX = float.Parse(parts[1]);
				float posY = float.Parse(parts[2]);
				float patDuration = float.Parse(parts[3]);
				string prefabName = parts[4];
				float patRot = 0f; // ���÷� 0���� ����. �ʿ信 ���� ����
				int bulletNum = int.Parse(parts[6]);

				// �� �κп� �ʿ��� ó���� �߰��ϼ���.
				Vector2 patPos = new Vector2(posX, posY);
				GameObject patternPrefab = Resources.Load<GameObject>(prefabName);
				GameObject go = Instantiate(patternPrefab, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
				go.GetComponent<PatternData>().patStartTime = patStartTime;
				go.GetComponent<PatternData>().patDuration = patDuration;
				go.GetComponent<PatternData>().patRot = patRot;
				go.GetComponent<CircleBullet>().roundNum = bulletNum;
				// spawnData
				go.SetActive(false);
				patList.Add(go);
			}
		}

		while (true)
		{
			string line = reader2.ReadLine();
			if (line == null)
			{
				break;
			}
			if (line.StartsWith("#"))
			{
				continue;
			}
			string[] parts = line.Split('/');
			if (parts.Length == 5)
			{
				float patStartTime = float.Parse(parts[0]);
				float posX = float.Parse(parts[1]);
				float posY = float.Parse(parts[2]);
				float patDuration = float.Parse(parts[3]);
				string prefabName = parts[4];

				// �� �κп� �ʿ��� ó���� �߰��ϼ���.
				Vector2 patPos = new Vector2(posX, posY);
				float patRot = 0f; // ���÷� 0���� ����. �ʿ信 ���� ����
				GameObject patternPrefab = Resources.Load<GameObject>(prefabName);
				GameObject go = Instantiate(patternPrefab, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
				go.GetComponent<PatternData>().patStartTime = patStartTime;
				go.GetComponent<PatternData>().patDuration = patDuration;
				go.GetComponent<PatternData>().patRot = patRot;
				// spawnData
				go.SetActive(false);
				patList.Add(go);
			}
			else if (parts.Length == 6)
			{
				float patStartTime = float.Parse(parts[0]);
				float posX = float.Parse(parts[1]);
				float posY = float.Parse(parts[2]);
				float patDuration = float.Parse(parts[3]);
				string prefabName = parts[4];
				float patRot = float.Parse(parts[5]);

				// �� �κп� �ʿ��� ó���� �߰��ϼ���.
				Vector2 patPos = new Vector2(posX, posY);
				GameObject patternPrefab = Resources.Load<GameObject>(prefabName);
				GameObject go = Instantiate(patternPrefab, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
				go.GetComponent<PatternData>().patStartTime = patStartTime;
				go.GetComponent<PatternData>().patDuration = patDuration;
				go.GetComponent<PatternData>().patRot = patRot;
				// spawnData
				go.SetActive(false);
				patList.Add(go);
			}
			//circle bullet��
			else if (parts.Length == 7)
			{
				float patStartTime = float.Parse(parts[0]);
				float posX = float.Parse(parts[1]);
				float posY = float.Parse(parts[2]);
				float patDuration = float.Parse(parts[3]);
				string prefabName = parts[4];
				float patRot = 0f; // ���÷� 0���� ����. �ʿ信 ���� ����
				int bulletNum = int.Parse(parts[6]);

				// �� �κп� �ʿ��� ó���� �߰��ϼ���.
				Vector2 patPos = new Vector2(posX, posY);
				GameObject patternPrefab = Resources.Load<GameObject>(prefabName);
				GameObject go = Instantiate(patternPrefab, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
				go.GetComponent<PatternData>().patStartTime = patStartTime;
				go.GetComponent<PatternData>().patDuration = patDuration;
				go.GetComponent<PatternData>().patRot = patRot;
				go.GetComponent<CircleBullet>().roundNum = bulletNum;
				// spawnData
				go.SetActive(false);
				patList.Add(go);
			}
		}

		reader.Close();
		reader2.Close();
	}

    protected override void Update()
    {
		//������Ʈ Ǯ�� �����ϴ°�
		for (int i = patList.Count - 1; i > -1; i--)
		{
			if (patList[i] == null)
			{
				patList.RemoveAt(i);
				continue;
			}
			//patList[i].name = "pattern" + i;
		}

		//������Ʈ Ǯ�� �����ϴ°�

		foreach (Transform child in transform)
		{
			if (!patList.Contains(child.gameObject))
			{
				DestroyImmediate(child.gameObject);
			}
		}

	}

    IEnumerator StartPattern(float startTime, GameObject pattern)
    {
        yield return new WaitForSeconds(startTime);
        pattern.gameObject.SetActive(true);
    }
}
