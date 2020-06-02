using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSV_Test : MonoBehaviour
{
    // csv 파일의 상대 경로
    string path = "Datas/movement.csv";

    // 데이터를 받아올 변수 만들기
    public List<Dictionary<string, object>> myData = new List<Dictionary<string, object>>();

    // 싱글톤으로 만들기
    public static CSV_Test Instance;
    
    private void Awake()
    {
        // 만일, Instance 변수에 따로 할당된 값이 없다면...
        if (Instance == null)
        {
            // 이 스크립트를 Instance 변수에 할당하겠다.
            Instance = this;
        }
         
        // 데이터 파싱하기
        myData = CSV_Reader.Reader(path);        
    }


    void Start()
    {
        //print(myData[0]["2017년 1월"]);

        #region
        // 전체 데이터 출력하기
        //for(int i = 0; i < myData.Count; i++)
        //{
        //    foreach(KeyValuePair<string, object> data in myData[i])
        //    {
        //        print(i + "번째 줄: " + data);
        //    }            
        //}


        //for(int i = 0; i< myData.Count; i++)
        //{
        //    // 만일, 이름이 "김현진"이라면...
        //    if(myData[i]["이름"].ToString() == "김현진")
        //    {
        //        // 그 데이터 라인의 이메일 값을 출력하겠다.
        //        string mailAddress = myData[i]["이메일"].ToString();
        //        print(mailAddress);
        //        break;
        //    }
        //}      
        #endregion
    }

}
