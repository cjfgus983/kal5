using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class PatternManager : MonoBehaviour
{
    public List<GameObject> patList = new List<GameObject>();

    public GameObject patternManager;
    [Tooltip("pattern start position")]
    public Vector2 patPos;

    [Tooltip("When pattern start")]
    public float patStartTime;

    [Tooltip("pattern duration time")]
    public float patDuration;

    [Tooltip("pattern start rotation")]
    public float patRot;

    [Tooltip("put the pattern prefab")]
    public GameObject pattern;

    PatternData pd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patternManager == null)
        {
            patternManager = GameObject.Find("PatternManager");
        }



        for (int i = patList.Count-1; i > -1; i--)
        {
            if (patList[i] == null)
            {
                patList.RemoveAt(i);
                continue;
            }
            //patList[i].name = "pattern" + i;
        }

        for (int i = transform.childCount-1; i > -1; i--)
        {
            if (!patList.Contains(transform.GetChild(i).gameObject))
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
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

    public void AddPattern()
    {
        GameObject go = Instantiate(pattern, patPos, Quaternion.Euler(0, 0, patRot), patternManager.transform);
        go.GetComponent<PatternData>().patStartTime = patStartTime;
        go.GetComponent<PatternData>().patDuration = patDuration;
        go.GetComponent<PatternData>().patRot = patRot;
        go.SetActive(false);
        patList.Add(go);

        patPos = Vector2.zero;
        patStartTime = 0.0f;
        patDuration = 0.0f;
        patRot = 0.0f;
    }

    IEnumerator StartPattern(float startTime, GameObject pattern)
    {
        yield return new WaitForSeconds(startTime);
        pattern.gameObject.SetActive(true);
    }
}
