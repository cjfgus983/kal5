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
        // ������ ȸ�� ���� �����ͼ� ����
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z = angle;

        // ȸ�� ����
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
