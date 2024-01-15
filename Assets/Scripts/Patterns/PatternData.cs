using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternData : MonoBehaviour
{
    public float patStartTime; //pattern start time
    public float patDuration; //pattern duration time
    public float patRot; //pattern start rotation
    public float patRotAng; //How much rotate
    public float patRotStartTime; //When pattern start rotate
    public float patRotTime; //How long pattern rotate

    bool startRotate;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        startRotate = false;
        StartCoroutine(SetFalse());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (patRotAng != 0 && startRotate)
        {
            if (transform.rotation != Quaternion.Euler(0, 0, patRot + patRotAng))
            {
                transform.Rotate(0, 0, patRotAng / patRotTime * Time.deltaTime);
            }
            
        }
    }

    protected virtual IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(patDuration);
        gameObject.SetActive(false);
    }

    protected virtual IEnumerator StartRotate(float startTime)
    {
        yield return new WaitForSeconds(startTime);
        startRotate = true;
    }
}

