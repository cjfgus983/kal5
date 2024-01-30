using System.Collections;
using System.Collections.Generic;
using System.IO;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

public class PatternManager_Ch : MonoBehaviour
{

    public List<GameObject> patList = new List<GameObject>();

    public GameObject patternManager;

    PatternData pd;

    public TextAsset textFile;

	private void Awake()
	{
        StringReader reader = new StringReader(textFile.text);

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
        }

        reader.Close();
    }

	void Start()
    {
        PatternStart();
    }

    void Update()
    {

        for (int i = patList.Count - 1; i > -1; i--)
        {
            if (patList[i] == null)
            {
                patList.RemoveAt(i);
                continue;
            }
            //patList[i].name = "pattern" + i;
        }

        foreach (Transform child in transform)
        {
            if (!patList.Contains(child.gameObject))
            {
                DestroyImmediate(child.gameObject);
            }
        }

    }

    public void PatternStart()
    {
        for (int i = 0; i < patList.Count; i++)
        {
            StartCoroutine(StartPattern(patList[i].GetComponent<PatternData>().patStartTime, patList[i]));
        }
    }

    IEnumerator StartPattern(float startTime, GameObject pattern)
    {
        yield return new WaitForSeconds(startTime);
        pattern.gameObject.SetActive(true);
    }
}
