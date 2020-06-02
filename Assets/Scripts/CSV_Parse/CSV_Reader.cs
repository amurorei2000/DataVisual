using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CSV_Reader
{
    public static List<Dictionary<string, object>> Reader(string filePath)
    {
        // csv 데이터를 담을 변수 선언
        List<Dictionary<string, object>> temp = new List<Dictionary<string, object>>();

        // 파일을 경로에서 읽어오기
        // 1. H.D.D 에 저장된 파일에 스트림 연결하기(파일 열기, 파일 읽어오는 모드)
        FileStream fs = new FileStream(Application.dataPath + "/" + filePath, FileMode.Open, FileAccess.Read);

        // 2. 생성된 스트림으로부터 내용을 읽어오기 위한 준비
        //  -> 1) csv 파일의 인코딩이 ANSI일 경우
        //StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("euc-kr"));
        //  -> 2) csv 파일의 인코딩이 utf-8일 경우
        StreamReader sr = new StreamReader(fs, Encoding.UTF8);

        // 3. 준비가 완료되었으면 내용물을 문자열(string) 변수에 담기
                
        // 방법 1) 데이터 전체의 문자열을 한꺼번에 다 읽어서 string 변수에 저장한다.
        string origin = sr.ReadToEnd();

        // 4. 라인별로 데이터를 나누기
        string[] originData = origin.Split('\n');
        
        for (int i = 0; i < originData.Length; i++)
        {
            // 방법 1) 다시 split 하기
            //string[] realRows = rows[i].Split('\r');
            //rows[i] = realRows[0];

            // 방법 2) '\r' 문자를 '' 문자로 교체하기 or 삭제하기
            if (i < originData.Length - 1)
            {
                //rows[i] = rows[i].Replace('\r', ' ');
                originData[i] = originData[i].Remove(originData[i].Length - 1);
            }
        }

        #region

        // 방법 2) 데이터 전체의 문자열을 한줄씩 매번 읽어서 string 배열에 저장한다.
        //int lineCount = line;
        //string[] originData = new string[lineCount];

        //// 데이터 라인 수만큼 반복하여 읽어서 저장하기
        //for(int i = 0; i < lineCount; i++)
        //{
        //    originData[i] = sr.ReadLine();
        //}
        #endregion

        // 4. 헤더 부분을 자르기
        string[] header = originData[0].Split(',');

        // 5. 자료형 부분을 자르기
        string[] dataType = originData[1].Split(',');
                        
        // 6. 각 데이터 값들을 자르기
        for(int i = 2; i < originData.Length; i++)
        {
            // 분할된 라인 string 변수가 비어있다면, 파싱을 종료한다.
            if(originData[i] == "" || originData[i] == null)
            {
                break;
            }

            // 임시 딕셔너리 변수 만들기
            Dictionary<string, object> lineValue = new Dictionary<string, object>();

            // 3번째 줄부터 ,를 기준으로 자르기
            string[] values = originData[i].Split(',');

            // 임시 딕셔너리 변수에 헤더와 값을 짝지어서 저장하기
            for(int j = 0; j < header.Length && j < values.Length; j++)
            {
                lineValue.Add(header[j], values[j]);
            }

            temp.Add(lineValue);
        }

        return temp;
    }
}
