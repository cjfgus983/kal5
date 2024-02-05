using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : PatternData
{

    protected override void Start()
    {
        float disT = patDuration - patStartTime;
        Invoke("RemoveObject", disT);

        Transform childTransform = transform.Find("lazerpointer");
        Lazer lazerpointer = childTransform.GetComponent<Lazer>();
        //lazerpointer.timeDestroy = patDuration;
    }

	protected override void Update()
	{
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
