using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class Read_ArrayData : MonoBehaviour
{
    // 저장 경로
    string path = "/Datas";

    // 저장될 파일 이름
    string fileName = "Visualization.json";

    private void Start()
    {
        // 상대 경로를 절대 경로로 변경하기
        path = Application.dataPath + path;

        // 데이터 저장하기
        //OnDataSave();

        // 데이터 읽어오기
        OnDataLoad();
    }

    // 데이터를 json 파일로 저장하는 함수
    public void OnDataSave()
    {
        // 1. 클래스 변수 만들기
        ArrayData arrData = new ArrayData();

        // 2. 클래스 변수에 값 넣기
        arrData.names[0] = "박원석";
        arrData.ages[0] = 39;
        arrData.jobs[0] = "강사";

        arrData.names[1] = "김현진";
        arrData.ages[1] = 37;
        arrData.jobs[1] = "강사";

        arrData.names[2] = "한임효";
        arrData.ages[2] = 32;
        arrData.jobs[2] = "강사";

        // 3. 클래스 변수를 json 파일로 저장한다.
        // 3-1. 클래스 변수의 내용을 json 형식으로 변환해서 string 변수에 넣기.
        //string jData = JsonUtility.ToJson(arrData, true);
        string jData = JsonConvert.SerializeObject(arrData);
        //print(jData);
        // 3-2. json 형태로 변환된 string 변수를 json 파일로 저장한다.        
        //FileStream fs = new FileStream(path + "/" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
        //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        //sw.Write(jData);
        //sw.Close();
        //fs.Close();

        File.WriteAllText(path + "/" + fileName, jData, System.Text.Encoding.UTF8);
    }

    // 데이터를 json 파일에서 읽어오는 함수
    public void OnDataLoad()
    {
        // 1. json 파일을 열어서 안에 있는 문자열 데이터를 읽어오기
        //FileStream fs = new FileStream(path + "/" + fileName, FileMode.Open, FileAccess.Read);
        //StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
        //string readData = sr.ReadToEnd();
        //sr.Close();
        //fs.Close();

        string readData = File.ReadAllText(path + "/" + fileName, System.Text.Encoding.UTF8);
        
        //print(readData);

        // 2. 읽어온 데이터를 클래스 변수로 변환하기
        ArrayData readArr = new ArrayData();
        //readArr = JsonUtility.FromJson<ArrayData>(readData);
        readArr = JsonConvert.DeserializeObject<ArrayData>(readData);
        
        // 3. 클래스 변수 값을 모두 출력하기
        for(int i= 0; i < name.Length; i++)
        {
            string name = readArr.names[i];
            int age = readArr.ages[i];
            string job = readArr.jobs[i];

            print(i +": " + name + ", " + age + ", " + job);
        }
    }
}
