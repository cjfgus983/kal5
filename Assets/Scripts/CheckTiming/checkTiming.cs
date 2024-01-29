using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class checkTiming : MonoBehaviour
{
    private float clickTime;

    void Update()
    {
        // 마우스 왼쪽 버튼이 눌렸을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 현재 시간을 저장
            clickTime = Time.time;
            SaveClickTimeToFile(clickTime);
        }
    }

    void SaveClickTimeToFile(float time)
    {

        // 바탕화면 경로를 얻어옴
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        // 파일 경로를 바탕화면 경로에 "ClickTimes.txt"로 설정
        string filePath = Path.Combine(desktopPath, "ClickTimes.txt");

        string formattedTime = time.ToString("F2");

        // 파일이 없으면 생성하고, 있으면 내용을 추가
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(formattedTime + "/0/0/3/bullet_blue");
        }
    }
}
