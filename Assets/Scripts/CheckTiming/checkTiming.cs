using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class checkTiming : MonoBehaviour
{
    private float clickTime;

    void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���� �ð��� ����
            clickTime = Time.time;
            SaveClickTimeToFile(clickTime);
        }
    }

    void SaveClickTimeToFile(float time)
    {

        // ����ȭ�� ��θ� ����
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        // ���� ��θ� ����ȭ�� ��ο� "ClickTimes.txt"�� ����
        string filePath = Path.Combine(desktopPath, "ClickTimes.txt");

        string formattedTime = time.ToString("F2");

        // ������ ������ �����ϰ�, ������ ������ �߰�
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(formattedTime + "/0/0/3/bullet_blue");
        }
    }
}
