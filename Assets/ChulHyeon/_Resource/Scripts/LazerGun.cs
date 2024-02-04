using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : PatternData
{
    // Start is called before the first frame update
    protected override void Start()
    {
        float disT = patDuration - patStartTime;
        Invoke("RemoveObject", disT);

        //if (transform.position.x < -4f)
        //{
        //    RotateObject(180f);
        //}
        Transform childTransform = transform.Find("lazerpointer");
        Lazer lazerpointer = childTransform.GetComponent<Lazer>();
        //lazerpointer.timeDestroy = patDuration;
    }
    void RemoveObject()
    {
        Destroy(gameObject);
    }
    void RotateObject(float angle)
    {
        // 현재의 회전 값을 가져와서 수정
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z = angle;

        // 회전 적용
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
